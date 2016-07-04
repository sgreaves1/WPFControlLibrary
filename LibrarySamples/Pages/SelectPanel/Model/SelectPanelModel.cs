using MyLibrary.SelectPanel;

namespace LibrarySamples.Pages.SelectPanel.Model
{
    class SelectPanelModel : IPanelItem
    {
        public SelectPanelModel (string name)
        {
            Name = name;
            IsSelected = false;
        }

        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
