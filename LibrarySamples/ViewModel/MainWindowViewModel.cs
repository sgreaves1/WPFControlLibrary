using System.Collections.ObjectModel;
using System.Windows.Controls;
using LibrarySamples.Pages.Home;

namespace LibrarySamples.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        private Model.Model _selectedPage;
        private ObservableCollection<Model.Model> _pageList = new ObservableCollection<Model.Model>();
        private Page _currentPage;
        private Frame _frame;

        public MainWindowViewModel(Frame frame)
        {
            _frame = frame;
            GoHome();
        }

        public void GoHome()
        {
            _currentPage = new HomePage();
            GoToPage();
        }

        public void GoToPage()
        {
            _frame.Navigate(_currentPage);
        }

        public Model.Model SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                _selectedPage = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Model.Model> PageList
        {
            get { return _pageList; }
            set
            {
                _pageList = value;
                OnPropertyChanged();
            }
        }
    }
}
