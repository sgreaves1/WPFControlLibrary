using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MyLibrary.ProgressBarList;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for ProgressBarListUC.xaml
    /// </summary>
    public partial class ProgressBarListUc 
    {
        public IEnumerable<IProgressBarListItem> ItemsSource
        {
            get { return (IEnumerable<IProgressBarListItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<IProgressBarListItem>), typeof(ProgressBarListUc), null);
        
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ProgressBarListUc), null);
        
        public ProgressBarListUc()
        {
            InitializeComponent();
        }
    }
}
