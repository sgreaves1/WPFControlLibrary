using System.Collections.ObjectModel;

namespace LibrarySamples.ViewModel
{
    public class DesignerMainWindowViewModel
    {
        public Model.Model SelectedPage => new Model.Model("Media Control");

        public ObservableCollection<Model.Model> PageList => new ObservableCollection<Model.Model>() { SelectedPage, new Model.Model("Progress Bar List"), new Model.Model("Properties Control") };

        public string ControlTitle => SelectedPage.Name;
    }
}
