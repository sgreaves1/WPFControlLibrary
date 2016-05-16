using MyLibrary.ProgressBarList;

namespace MyLibrary
{
    public class DesignProgressBarListItem
    {
        public IProgressBarListItem[] ItemsSource => new IProgressBarListItem[] { new DesignItem("Sam", "", 1, 28, 100), new DesignItem("Dave", "", 1, 23, 100)  };

        public string Title => "Title";
    }

    public class DesignItem : IProgressBarListItem
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int MinValue { get; set; }
        public int Value { get; set; }
        public int MaxValue { get; set; }

        public DesignItem(string name, string imageName, int minValue, int value, int maxValue)
        {
            Name = name;
            ImageName = imageName;
            MinValue = minValue;
            Value = value;
            MaxValue = maxValue;

        }
    }
}
