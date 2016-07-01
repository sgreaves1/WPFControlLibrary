using MyLibrary.ProgressBarList;

namespace LibrarySamples.Pages.ProgressList.Model
{
    public class ProgressBarListModel : IProgressBarListItem
    {
        public ProgressBarListModel(string name, string imageName, int minValue, int value, int maxValue)
        {
            Name = name;
            ImageName = imageName;
            MinValue = minValue;
            Value = value;
            MaxValue = maxValue;
        }

        public string Name { get; set; }
        public string ImageName { get; set; }
        public int MinValue { get; set; }
        public int Value { get; set; }
        public int MaxValue { get; set; }
    }
}
