using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MyLibrary.ProgressBarList;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for ProgressBarListUC.xaml
    /// </summary>
    public partial class ProgressBarListUc : INotifyPropertyChanged
    {
        // Using a DependencyProperty as the backing store for ListItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty 
            = DependencyProperty.Register("ItemsSource", 
              typeof(IEnumerable<IProgressBarListItem>), 
              typeof(ProgressBarListUc), 
              new FrameworkPropertyMetadata(null, OnItemsPropertyChanged, null),
              null);
        
        
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty 
            = DependencyProperty.Register("Title", 
                typeof(string), 
                typeof(ProgressBarListUc), 
                null);

        
        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty 
            = DependencyProperty.Register("Total", 
                typeof(int), typeof(ProgressBarListUc), 
                new PropertyMetadata(0));

        
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty 
            = DependencyProperty.Register("Value", 
                typeof(int), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(0));
        

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", 
                typeof(int), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(0));

        
        // Using a DependencyProperty as the backing store for TotalProgressBarVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProgressBarVisibleProperty =
            DependencyProperty.Register("IsTotalProgressBarVisible", 
                typeof(bool), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(false));


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", 
                typeof(ICommand), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(null));


        // Using a DependencyProperty as the backing store for CanUserDeleteItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanUserDeleteItemsProperty =
            DependencyProperty.Register("CanUserDeleteItems", 
                typeof(bool), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(false));


        public ProgressBarListUc()
        {
            InitializeComponent();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<IProgressBarListItem> ItemsSource
        {
            get { return (IEnumerable<IProgressBarListItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        private int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public bool IsTotalProgressBarVisible
        {
            get { return (bool)GetValue(TotalProgressBarVisibleProperty); }
            set { SetValue(TotalProgressBarVisibleProperty, value); }
        }

        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }
        
        public bool CanUserDeleteItems
        {
            get { return (bool)GetValue(CanUserDeleteItemsProperty); }
            set { SetValue(CanUserDeleteItemsProperty, value); }
        }

        





        /// <summary>
        /// Property changed function for when one of the items changes
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnItemsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ProgressBarListUc userControl = source as ProgressBarListUc;

            if (userControl != null)
            {
                userControl.Total = 0;
                userControl.Value = 0;
                userControl.Minimum = 0;

                foreach (IProgressBarListItem item in userControl.ItemsSource)
                {
                    userControl.Total += item.MaxValue;
                    userControl.Value += item.Value;
                    userControl.Minimum += item.MinValue;
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IProgressBarListItem item = ((FrameworkElement)sender).DataContext as IProgressBarListItem;
            
        }
    }
}
