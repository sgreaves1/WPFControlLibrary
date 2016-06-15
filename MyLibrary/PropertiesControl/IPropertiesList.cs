using System.Collections.ObjectModel;

namespace MyLibrary.PropertiesControl
{
    public interface IPropertiesList
    {
        string Name { get; set; }
        
        ObservableCollection<IPropertyBase> PropertyList { get; set; } 
    }
}
