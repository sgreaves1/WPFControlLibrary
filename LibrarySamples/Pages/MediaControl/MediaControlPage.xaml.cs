using System;
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

        public MediaControlPage()
        {
            InitializeComponent();

            ViewModel = new MediaControlViewModel();
            DataContext = ViewModel;

            ViewModel.StopRequested += (sender, args) =>
            {
                VideoPlayer.Close();
            };

            ViewModel.RewindRequested += (sender, args) =>
            {
                if (VideoPlayer.SpeedRatio >= 0)
                {
                    VideoPlayer.SpeedRatio = -1;
                }
                else
                {
                    VideoPlayer.SpeedRatio = VideoPlayer.SpeedRatio * 2;
                }
            };

            ViewModel.PlayRequested += (sender, args) =>
            {
                VideoPlayer.SpeedRatio = 1;
                VideoPlayer.Play();
            };

            ViewModel.FastForwardRequested += (sender, args) =>
            {
                //VideoPlayer.Position = VideoPlayer.Position + TimeSpan.FromSeconds(10);
                //if (VideoPlayer.Position >= VideoPlayer.NaturalDuration.TimeSpan)
                //{
                //    VideoPlayer.Position -= TimeSpan.FromMilliseconds(100);
                //}
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
    }
}
