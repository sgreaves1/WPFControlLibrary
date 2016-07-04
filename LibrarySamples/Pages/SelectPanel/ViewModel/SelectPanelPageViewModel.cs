using System.Collections.ObjectModel;
using System.ComponentModel;
using LibrarySamples.Pages.SelectPanel.Model;
using LibrarySamples.ViewModel;
using MyLibrary.SelectPanel;

namespace LibrarySamples.Pages.SelectPanel.ViewModel
{
    public class SelectPanelPageViewModel : BaseViewModel
    {
        private ObservableCollection<IPanelItem> _items = new ObservableCollection<IPanelItem>();

        public SelectPanelPageViewModel()
        {
            GetModels();
        }

        private void GetModels()
        {
            Items.Add(new SelectPanelModel("Sam"));
            Items.Add(new SelectPanelModel("Tim"));
        }

        public ObservableCollection<IPanelItem> Items
        {
            get {  return _items; }
            set
            {
                _items = value; 
                OnPropertyChanged();
            }
        }  
    }
}
