using System.Collections.Generic;
using System.Windows;
using MyLibrary.PropertiesControl;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for PropertiesControl.xaml
    /// </summary>
    public partial class PropertiesControlUc 
    {
        /// <summary>
        /// Dependency Property that is used for the item source
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", 
                typeof(IEnumerable<IPropertiesList>), 
                typeof(PropertiesControlUc), 
                new PropertyMetadata(null));

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PropertiesControlUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The items source that populates the data for this control
        /// </summary>
        public IEnumerable<IPropertiesList> ItemsSource
        {
            get { return (IEnumerable<IPropertiesList>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
    }
}
