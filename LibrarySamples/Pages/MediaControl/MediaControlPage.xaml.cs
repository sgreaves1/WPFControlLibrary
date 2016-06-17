using System;
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

            ViewModel.PlayRequested += (sender, args) =>
            {
                VideoPlayer.Play();
            };

            ViewModel.FastForwardRequested += (sender, args) =>
            {
                VideoPlayer.Position = VideoPlayer.Position + TimeSpan.FromSeconds(10);
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
