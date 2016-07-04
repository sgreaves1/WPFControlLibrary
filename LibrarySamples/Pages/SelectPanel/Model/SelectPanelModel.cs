using MyLibrary.SelectPanel;

namespace LibrarySamples.Pages.SelectPanel.Model
{
    class SelectPanelModel : IPanelItem
    {
        public SelectPanelModel (string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
