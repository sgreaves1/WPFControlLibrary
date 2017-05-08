using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using MyLibrary.Annotations;
using MyLibrary.SelectPanel;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for SelectPanelUc.xaml
    /// </summary>
    public partial class SelectPanelUc : INotifyPropertyChanged
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
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
                typeof(IPanelItem),
                typeof(SelectPanelUc),
                new PropertyMetadata(null));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty PanelHeightProperty =
            DependencyProperty.Register("PanelHeight", 
                typeof(double), 
                typeof(SelectPanelUc), 
                new PropertyMetadata(50.0));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SearchVisibleProperty =
            DependencyProperty.Register("SearchVisible", 
                typeof(bool), 
                typeof(SelectPanelUc), 
                new PropertyMetadata(true));

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

        /// <summary>
        /// 
        /// </summary>
        public IPanelItem SelectedItem
        {
            get { return (IPanelItem)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double PanelHeight
        {
            get { return (double)GetValue(PanelHeightProperty); }
            set { SetValue(PanelHeightProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SearchVisible
        {
            get { return (bool)GetValue(SearchVisibleProperty); }
            set { SetValue(SearchVisibleProperty, value); }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedItem = (IPanelItem) ((ToggleButton) sender).DataContext;

            SelectedItem.IsSelected = true;

            foreach (var item in ItemsSource)
            {
                if (item != SelectedItem)
                {
                    item.IsSelected = false;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
