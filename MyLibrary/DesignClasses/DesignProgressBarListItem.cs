using MyLibrary.ProgressBarList;

namespace MyLibrary.DesignClasses
{
    public class DesignProgressBarList
    {
        public IProgressBarListItem[] ItemsSource => new IProgressBarListItem[] { new DesignProgressBarListItem("Sam", "", 1, 28, 100), new DesignProgressBarListItem("Dave", "", 1, 23, 100) };

        public string Title => "Title";

        public bool IsTotalProgressBarVisible => true;
    }

    public class DesignProgressBarListItem : IProgressBarListItem
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int MinValue { get; set; }
        public int Value { get; set; }
        public int MaxValue { get; set; }

        public DesignProgressBarListItem(string name, string imageName, int minValue, int value, int maxValue)
        {
            Name = name;
            ImageName = imageName;
            MinValue = minValue;
            Value = value;
            MaxValue = maxValue;

        }
    }
}
