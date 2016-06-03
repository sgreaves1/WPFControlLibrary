using MyLibrary.PropertiesControl;

namespace MyLibrary.DesignClasses
{
    public class DesignPropertiesControlUc
    {
        public IPropertiesList[] ItemsSource => new IPropertiesList[] { new DesignPropertiesControlItem("Properties"), new DesignPropertiesControlItem("Data"), new DesignPropertiesControlItem("Style"),   };
    }

    public class DesignPropertiesControlItem : IPropertiesList
    {
        public string Name { get; set; }

        public DesignPropertiesControlItem(string name)
        {
            Name = name;
        }
    }
}
