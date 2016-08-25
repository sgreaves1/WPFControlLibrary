using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using LibrarySamples.Command;
using LibrarySamples.Pages.Home;
using LibrarySamples.Pages.LineBusyIndicator;
using LibrarySamples.Pages.MediaControl;
using LibrarySamples.Pages.NumericUpDown;
using LibrarySamples.Pages.ProgressList;
using LibrarySamples.Pages.RotatingBusyIndicator;
using LibrarySamples.Pages.SelectiveList;
using LibrarySamples.Pages.SelectPanel;
using MyLibrary;
using MyLibrary.SelectPanel;

namespace LibrarySamples.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        private Model.Model _selectedPage;
        private ObservableCollection<IPanelItem> _pageList = new ObservableCollection<IPanelItem>();
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
                    case "Line Busy Indicator":
                        _currentPage = new LineBusyIndicatorPage();
                        GoToPage();
                        break;

                    case "Rotating Busy Indicator":
                        _currentPage = new RotatingBusyIndicatorPage();
                        GoToPage();
                        break;

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

                    case "Select Panel":
                        _currentPage = new SelectPanelPage();
                        GoToPage();
                        break;

                    case "Selective List":
                        _currentPage = new SelectiveListPage();
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
            PageList.Add(new Model.Model("Line Busy Indicator"));
            PageList.Add(new Model.Model("Rotating Busy Indicator"));
            PageList.Add(new Model.Model("Progress Bar List"));
            PageList.Add(new Model.Model("Media Control"));
            PageList.Add(new Model.Model("Numeric Up Down"));
            PageList.Add(new Model.Model("Select Panel"));
            PageList.Add(new Model.Model("Selective List"));
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

        public ObservableCollection<IPanelItem> PageList
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
