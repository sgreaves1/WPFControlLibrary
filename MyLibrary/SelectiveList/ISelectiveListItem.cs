namespace MyLibrary.SelectiveList
{
    /// <summary>
    /// Interface to describe the items displayed on the selective list user control
    /// </summary>
    public interface ISelectiveListItem
    {
        /// <summary>
        /// Name of the item that will be displayed on the selective list
        /// </summary>
        string Name { get; set; }
    }
}
