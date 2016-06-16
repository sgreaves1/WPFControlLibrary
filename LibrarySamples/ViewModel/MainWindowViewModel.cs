
using System.Collections.ObjectModel;

namespace LibrarySamples.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        private Model.Model _selectedPage;
        private ObservableCollection<Model.Model> _pageList = new ObservableCollection<Model.Model>();
        
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
