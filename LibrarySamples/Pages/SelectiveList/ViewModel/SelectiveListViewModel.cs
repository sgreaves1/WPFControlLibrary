using System.Collections.ObjectModel;
using LibrarySamples.Pages.SelectiveList.Model;
using LibrarySamples.ViewModel;
using MyLibrary.SelectiveList;

namespace LibrarySamples.Pages.SelectiveList.ViewModel
{
    public class SelectiveListViewModel : BaseViewModel
    {
        private ObservableCollection<ISelectiveListItem> _availibleItems = new ObservableCollection<ISelectiveListItem>();
        private ObservableCollection<ISelectiveListItem> _selectedItems = new ObservableCollection<ISelectiveListItem>();


        public SelectiveListViewModel()
        {
            AvailibleItems.Add(new SelectiveListModel("Sam"));
            AvailibleItems.Add(new SelectiveListModel("Liam"));
            AvailibleItems.Add(new SelectiveListModel("David"));
            AvailibleItems.Add(new SelectiveListModel("Matt"));
            AvailibleItems.Add(new SelectiveListModel("Justin"));
            AvailibleItems.Add(new SelectiveListModel("Mark"));
        }

        public ObservableCollection<ISelectiveListItem> AvailibleItems
        {
            get { return _availibleItems; }
            set
            {
                _availibleItems = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISelectiveListItem> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                OnPropertyChanged();
            }
        }
    }
}
