using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibrarySamples.Pages.MediaControl.ViewModel;

namespace LibrarySamples.Pages.MediaControl
{
    /// <summary>
    /// Interaction logic for MediaControlPage.xaml
    /// </summary>
    public partial class MediaControlPage 
    {
        private MediaControlViewModel _viewModel;

        private CancellationTokenSource _source;

        private TimeSpan RewindSpeed = new TimeSpan(0, 0, 0, 1);

        public MediaControlPage()
        {
            InitializeComponent();

            ViewModel = new MediaControlViewModel();
            DataContext = ViewModel;

            ViewModel.StopRequested += (sender, args) =>
            {
                _source?.Cancel();

                VideoPlayer.Close();
            };

            ViewModel.RewindRequested += (sender, args) =>
            {
                _source?.Cancel();

                VideoPlayer.Pause();

                _source = new CancellationTokenSource();
               
                Rewind(_source.Token);
            };

            ViewModel.PlayRequested += (sender, args) =>
            {
                _source?.Cancel();

                VideoPlayer.SpeedRatio = 1;
                VideoPlayer.Play();
            };

            ViewModel.FastForwardRequested += (sender, args) =>
            {
                _source?.Cancel();

                if (VideoPlayer.SpeedRatio <= 0)
                {
                    VideoPlayer.SpeedRatio = 1;
                }
                else
                {
                    VideoPlayer.SpeedRatio = VideoPlayer.SpeedRatio*2;
                }
            };

            ViewModel.EjectRequested += (sender, args) =>
            {
                _source?.Cancel();

                VideoPlayer.SpeedRatio = 1;
            };

            ViewModel.FullScreenRequested += (sender, args) =>
            {
            };

            ViewModel.UpdateTime += (sender, args) =>
            {
                ViewModel.PlayTime = VideoPlayer.Position;
            };
        }

        public MediaControlViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        /// <summary>
        ///  Run a task that will every now and then update the media element position
        ///  needs a cancelation token to be cancelled whenever another button is pressed
        ///  needs a a timer to run
        ///  when timer hits reverse position of video player by a value
        ///  increase the value every time the rewind button is hit
        /// </summary>
        /// <param name="cancellationToken"></param>
        private async void Rewind(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);

                // check here in case cancelled while delayed
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                VideoPlayer.Position = VideoPlayer.Position.Subtract(RewindSpeed);
            }
        }
    }
}
