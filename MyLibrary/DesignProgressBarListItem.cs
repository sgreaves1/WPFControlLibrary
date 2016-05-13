namespace MyLibrary
{
    public class DesignProgressBarListItem
    {
        public IProgressBarListItem[] ItemsSource => new IProgressBarListItem[] { new DesignItem("Sam", 30), new DesignItem("Dave", 1)  };

        public string Title => "Title";
    }

    public class DesignItem : IProgressBarListItem
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Value { get; set; }

        public DesignItem(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
