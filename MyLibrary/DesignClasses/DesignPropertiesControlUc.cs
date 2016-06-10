using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using MyLibrary.PropertiesControl;

namespace MyLibrary.DesignClasses
{
    public class DesignPropertiesControlUc
    {
        public IPropertiesList[] ItemsSource => new IPropertiesList[]
        {
            new DesignPropertiesControlList("Properties", new ObservableCollection<IPropertyBase>() {new DesignPropertiesControlItem<bool>() {Name = "Eject", Data = true} }),
            new DesignPropertiesControlList("Data", new ObservableCollection<IPropertyBase>()),
            new DesignPropertiesControlList("Style", new ObservableCollection<IPropertyBase>()),
        };
    }

    public class DesignPropertiesControlList : IPropertiesList
    {
        public string Name { get; set; }

        public ObservableCollection<IPropertyBase> PropertyList { get; set; }

        public DesignPropertiesControlList(string name, ObservableCollection<IPropertyBase> list )
        {
            Name = name;
            PropertyList = list;
        }
    }

    public class DesignPropertiesControlItem<T> : IProperty<T>
    {
        public string Name { get; set; }
        public T Data { get; set; }
    }
}
