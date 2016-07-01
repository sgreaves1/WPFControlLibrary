using System.Collections.ObjectModel;
using System.Windows.Input;
using LibrarySamples.Command;
using LibrarySamples.Pages.ProgressList.Model;
using LibrarySamples.ViewModel;

namespace LibrarySamples.Pages.ProgressList.ViewModel
{
    public class ProgressListPageViewModel : BaseViewModel
    {
        private ObservableCollection<ProgressBarListModel> _models = new ObservableCollection<ProgressBarListModel>();

        public ProgressListPageViewModel()
        {
            InitCommands();
            GetModels();
        }

        public void GetModels()
        {
            Models.Add(new ProgressBarListModel("Sam",
                "https://scontent-lhr3-1.xx.fbcdn.net/v/t1.0-9/12924461_565183000326585_1215744960396606756_n.jpg?oh=16da7b5e287d837c60a71b5ad06b20a1&oe=57D62849",
                0, 50, 50));

            Models.Add(new ProgressBarListModel("Matt",
                "https://scontent-lhr3-1.xx.fbcdn.net/v/t1.0-9/10426267_10152771923730124_4549022111893116764_n.jpg?oh=73a6c299e818979fc1f03437bef1b864&oe=57A21174",
                10, 10, 20));

            Models.Add(new ProgressBarListModel("Lima",
                "https://scontent-lhr3-1.xx.fbcdn.net/v/t1.0-9/399797_10150667838764379_1150661531_n.jpg?oh=8843c1e9ffe5fc72de3d7b249bd55ac7&oe=57AC4C29",
                0, 1, 100));
            Models.Add(new ProgressBarListModel("Dave",
                "https://scontent-lhr3-1.xx.fbcdn.net/v/t1.0-9/253424_10150191140082797_4206105_n.jpg?oh=d98ba77135897a1dd0fcf676cb82e464&oe=57A28851",
                0, 25, 30));
        }

        public ObservableCollection<ProgressBarListModel> Models
        {
            get { return _models; }
            set
            {
                _models = value;
                OnPropertyChanged();
            }
        }

        public string Title => "Progress Bar List Sample";

        public void InitCommands()
        {
            DeleteCommand = new DelegateCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
            AddItemCommand = new DelegateCommand(ExecuteAddItemCommand, CanExecuteAddItemCommand);
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand AddItemCommand { get; private set; }

        public bool CanExecuteDeleteCommand(object parameter)
        {
            return true;
        }

        public void ExecuteDeleteCommand(object parameter)
        {
            ProgressBarListModel item = parameter as ProgressBarListModel;

            Models.Remove(item);
        }

        public bool CanExecuteAddItemCommand(object parameter)
        {
            return true;
        }

        public void ExecuteAddItemCommand(object parameter)
        {
            Models.Add(new ProgressBarListModel("Sam",
                "https://scontent-lhr3-1.xx.fbcdn.net/v/t1.0-9/12924461_565183000326585_1215744960396606756_n.jpg?oh=16da7b5e287d837c60a71b5ad06b20a1&oe=57D62849",
                0, 50, 50));
        }
    }
}
