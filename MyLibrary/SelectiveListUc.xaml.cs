using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MyLibrary.SelectiveList;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for SelectiveListUc.xaml
    /// </summary>
    public partial class SelectiveListUc 
    {
        /// <summary>
        /// Dependency property for the <see cref="AvailibleItems"/> property.
        /// </summary>
        public static readonly DependencyProperty AvailibleItemsProperty =
            DependencyProperty.Register("AvailibleItems", 
                typeof(IEnumerable<ISelectiveListItem>), 
                typeof(SelectiveListUc), 
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency property for the <see cref="SelectedItems"/> property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems",
                typeof(IEnumerable<ISelectiveListItem>),
                typeof(SelectiveListUc),
                new PropertyMetadata(null));

        /// <summary>
        /// Constructor
        /// </summary>
        public SelectiveListUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Items to display in the available items list box
        /// </summary>
        public IEnumerable<ISelectiveListItem> AvailibleItems
        {
            get { return (IEnumerable<ISelectiveListItem>)GetValue(AvailibleItemsProperty); }
            set { SetValue(AvailibleItemsProperty, value); }
        }

        /// <summary>
        /// Items to display in the selected items list box
        /// </summary>
        public IEnumerable<ISelectiveListItem> SelectedItems
        {
            get { return (IEnumerable<ISelectiveListItem>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
    }
}
