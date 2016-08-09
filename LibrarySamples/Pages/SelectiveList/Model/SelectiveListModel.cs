using MyLibrary.SelectiveList;

namespace LibrarySamples.Pages.SelectiveList.Model
{
    public class SelectiveListModel : ISelectiveListItem
    {
        public SelectiveListModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
