using System.Collections.ObjectModel;
using System.Windows;
using MyLibrary.SelectPanel;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for SelectPanelUc.xaml
    /// </summary>
    public partial class SelectPanelUc
    {
       /// <summary>
       /// 
       /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", 
                typeof(ObservableCollection<IPanelItem>), 
                typeof(SelectPanelUc), 
                new PropertyMetadata(null));

        /// <summary>
        /// Constructor
        /// </summary>
        public SelectPanelUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<IPanelItem> ItemsSource
        {
            get { return (ObservableCollection<IPanelItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
    }
}
