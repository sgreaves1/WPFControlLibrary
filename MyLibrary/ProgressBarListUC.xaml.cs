using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MyLibrary.ProgressBarList;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for ProgressBarListUC.xaml
    /// </summary>
    public partial class ProgressBarListUc : INotifyPropertyChanged
    {
        public IEnumerable<IProgressBarListItem> ItemsSource
        {
            get { return (IEnumerable<IProgressBarListItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", 
                typeof(IEnumerable<IProgressBarListItem>), 
                typeof(ProgressBarListUc), new FrameworkPropertyMetadata(null, OnItemsPropertyChanged, null), null);

        private static void OnItemsPropertyChanged(DependencyObject source,
        DependencyPropertyChangedEventArgs e)
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

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ProgressBarListUc), null);

        private int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(int), typeof(ProgressBarListUc), new PropertyMetadata(0));

        private int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(ProgressBarListUc), new PropertyMetadata(0));

        private int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(ProgressBarListUc), new PropertyMetadata(0));

        public ProgressBarListUc()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
