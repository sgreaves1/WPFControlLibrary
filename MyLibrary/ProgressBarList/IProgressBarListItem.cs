namespace MyLibrary.ProgressBarList
{
    public interface IProgressBarListItem
    {
        string Name { get; set; }
        string ImageName { get; set; }
        int MinValue { get; set; }
        int Value { get; set; }
        int MaxValue { get; set; }
    }
}

