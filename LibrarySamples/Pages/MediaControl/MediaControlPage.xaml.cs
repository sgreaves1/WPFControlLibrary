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
        }

        public MediaControlViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }
    }
}
