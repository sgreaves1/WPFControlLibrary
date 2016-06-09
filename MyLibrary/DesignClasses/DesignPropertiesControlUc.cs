using System.Collections.ObjectModel;
using MyLibrary.PropertiesControl;

namespace MyLibrary.DesignClasses
{
    public class DesignPropertiesControlUc
    {
        public IPropertiesList[] ItemsSource => new IPropertiesList[]
        {
            new DesignPropertiesControlList("Properties", new ObservableCollection<IProperty>() {new DesignPropertiesControlItem("Eject")}),
            new DesignPropertiesControlList("Data", new ObservableCollection<IProperty>()),
            new DesignPropertiesControlList("Style", new ObservableCollection<IProperty>()),
        };
    }

    public class DesignPropertiesControlList : IPropertiesList
    {
        public string Name { get; set; }

        public ObservableCollection<IProperty> PropertyList { get; set; }

        public DesignPropertiesControlList(string name, ObservableCollection<IProperty> list )
        {
            Name = name;
            PropertyList = list;
        }
    }

    public class DesignPropertiesControlItem : IProperty
    {
        public string Name { get; set; }

        public DesignPropertiesControlItem(string name)
        {
            Name = name;
        }
    }
}
