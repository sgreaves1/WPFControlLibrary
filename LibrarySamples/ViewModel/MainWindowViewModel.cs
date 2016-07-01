using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using LibrarySamples.Command;
using LibrarySamples.Pages.Home;
using LibrarySamples.Pages.MediaControl;
using LibrarySamples.Pages.NumericUpDown;
using LibrarySamples.Pages.ProgressList;

namespace LibrarySamples.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        private Model.Model _selectedPage;
        private ObservableCollection<Model.Model> _pageList = new ObservableCollection<Model.Model>();
        private string _controlTitle;
        private Page _currentPage;
        private Frame _frame;

        public MainWindowViewModel(Frame frame)
        {
            _frame = frame;
            GoHome();
            InitCommands();
            GetModels();
        }

        public void GoHome()
        {
            _currentPage = new HomePage();
            ControlTitle = "Home";
            GoToPage();
        }

        public void GoToPage()
        {
            _frame.Navigate(_currentPage);
        }

        public void ChangePage()
        {
            if (SelectedPage != null)
            {
                ControlTitle = SelectedPage.Name;
                switch (SelectedPage.Name)
                {
                    case "Progress Bar List":
                        _currentPage = new ProgressListPage();
                        GoToPage();
                        break;

                    case "Media Control":
                        _currentPage = new MediaControlPage();
                        GoToPage();
                        break;

                    case "Numeric Up Down":
                        _currentPage = new NumericUpDownPage();
                        GoToPage();
                        break;

                    default:
                        GoHome();
                        break;
                }
            }
        }

        public void GetModels()
        {
            PageList.Add(new Model.Model("Progress Bar List"));
            PageList.Add(new Model.Model("Media Control"));
            PageList.Add(new Model.Model("Numeric Up Down"));
        }

        public Model.Model SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                _selectedPage = value;
                OnPropertyChanged();

                ChangePage();
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

        public string ControlTitle
        {
            get { return _controlTitle; }
            set
            {
                _controlTitle = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public void InitCommands()
        {
            HomePageCommand = new RelayCommand(ExecuteHomePageCommand, CanExecuteHomePageCommand);
        }

        public ICommand HomePageCommand { get; private set; }

        public bool CanExecuteHomePageCommand()
        {
            if (_currentPage.GetType() != typeof(HomePage))
            {
                return true;
            }

            return false;
        }

        public void ExecuteHomePageCommand()
        {
            GoHome();
            SelectedPage = null;
        }

        #endregion
    }
}
