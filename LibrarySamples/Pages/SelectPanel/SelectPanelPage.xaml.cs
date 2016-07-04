using LibrarySamples.Pages.SelectPanel.ViewModel;

namespace LibrarySamples.Pages.SelectPanel
{
    /// <summary>
    /// Interaction logic for SelectPanelPage.xaml
    /// </summary>
    public partial class SelectPanelPage
    {
        public SelectPanelPage()
        {
            InitializeComponent();

            DataContext = new SelectPanelPageViewModel();
        }
    }
}
