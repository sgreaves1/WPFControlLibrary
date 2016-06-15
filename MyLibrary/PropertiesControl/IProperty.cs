
namespace MyLibrary.PropertiesControl
{
    /// <summary>
    /// Interface to describe what each property in the control needs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProperty<T> : IPropertyBase
    {
        /// <summary>
        /// Data and type of the property
        /// </summary>
        T Data { get; set; }
    }
}
