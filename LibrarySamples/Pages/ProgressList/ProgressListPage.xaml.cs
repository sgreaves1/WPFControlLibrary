using LibrarySamples.Pages.ProgressList.ViewModel;

namespace LibrarySamples.Pages.ProgressList
{
    /// <summary>
    /// Interaction logic for ProgressListPage.xaml
    /// </summary>
    public partial class ProgressListPage
    {
        public ProgressListPage()
        {
            InitializeComponent();

            DataContext = new ProgressListPageViewModel();
        }
    }
}
