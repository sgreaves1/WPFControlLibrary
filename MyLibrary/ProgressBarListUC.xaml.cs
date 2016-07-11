using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyLibrary.ProgressBarList;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for ProgressBarListUC.xaml
    /// </summary>
    public partial class ProgressBarListUc : INotifyPropertyChanged
    {
        /// <summary>
        /// Dependency property for the <see cref="Orientation"/> property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", 
                typeof(Orientation), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(Orientation.Horizontal));


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
        
        /// <summary>
        /// Dependency Property for the visibility of the IntergerUpDownControls
        /// </summary>
        public static readonly DependencyProperty CanUserAlterProgressProperty =
            DependencyProperty.Register("CanUserAlterProgress", 
                typeof(bool), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(false));
        
        /// <summary>
        /// Dependency Property for the add item button command
        /// </summary>
        public static readonly DependencyProperty AddItemCommandProperty =
            DependencyProperty.Register("AddItemCommand", 
                typeof(ICommand), 
                typeof(ProgressBarListUc), 
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency Property for the visibility of the Add button
        /// </summary>
        public static readonly DependencyProperty CanUserAddItemProperty = 
            DependencyProperty.Register("CanUserAddItem",
                typeof(bool),
                typeof(ProgressBarListUc),
                new PropertyMetadata(true));

        /// <summary>
        /// Dependency Property for the image data of the Add button
        /// </summary>
        public static readonly DependencyProperty DeleteButtonDataProperty =
            DependencyProperty.Register("DeleteButtonData",
                typeof(string),
                typeof(ProgressBarListUc),
                new PropertyMetadata("F1 M24, 24z M0, 0z M6, 19C6, 20.1, 6.9, 21, 8, 21L16, 21C17.1, 21, 18, 20.1, 18, 19L18, 7 6, 7 6, 19z M8.46, 11.88L9.87, 10.47 12, 12.59 14.12, 10.47 15.53, 11.88 13.41, 14 15.53, 16.12 14.12, 17.53 12, 15.41 9.88, 17.53 8.47, 16.12 10.59, 14 8.46, 11.88z M15.5, 4L14.5, 3 9.5, 3 8.5, 4 5, 4 5, 6 19, 6 19, 4z"));


        /// <summary>
        /// Dependency Property for the image data of the Add button
        /// </summary>
        public static readonly DependencyProperty AddButtonDataProperty =
            DependencyProperty.Register("AddButtonData",
                typeof(string),
                typeof(ProgressBarListUc),
                new PropertyMetadata("F1 M24,24z M0,0z M19,13L13,13 13,19 11,19 11,13 5,13 5,11 11,11 11,5 13,5 13,11 19,11 19,13z"));


        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProgressBarListUc()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the orientation of the progress bar list
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public IEnumerable<IProgressBarListItem> ItemsSource
        {
            get { return (IEnumerable<IProgressBarListItem>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
                OnPropertyChanged();
            }
        }

        private int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set
            {
                SetValue(TotalProperty, value); 
                OnPropertyChanged();
            }
        }

        private int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                OnPropertyChanged();
            }
        }

        private int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set
            {
                SetValue(MinimumProperty, value);
                OnPropertyChanged();
            }
        }

        public bool IsTotalProgressBarVisible
        {
            get { return (bool)GetValue(TotalProgressBarVisibleProperty); }
            set
            {
                SetValue(TotalProgressBarVisibleProperty, value);
                OnPropertyChanged();
            }
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
        /// True if the progress bars can be edited with in the view
        /// </summary>
        public bool CanUserAlterProgress
        {
            get { return (bool)GetValue(CanUserAlterProgressProperty); }
            set { SetValue(CanUserAlterProgressProperty, value); }
        }

        /// <summary>
        /// Command that executes when the add button is clicked
        /// </summary>
        public ICommand AddItemCommand
        {
            get { return (ICommand)GetValue(AddItemCommandProperty); }
            set { SetValue(AddItemCommandProperty, value); }
        }

        /// <summary>
        /// True if user can click the add button
        /// </summary>
        public bool CanUserAddItem
        {
            get { return (bool)GetValue(CanUserAddItemProperty); }
            set { SetValue(CanUserAddItemProperty, value); }
        }

        /// <summary>
        /// The image for the delete button in geometry data form
        /// </summary>
        public string DeleteButtonData
        {
            get { return (string)GetValue(DeleteButtonDataProperty); }
            set { SetValue(DeleteButtonDataProperty, value); }
        }

        /// <summary>
        /// The image for the add button in geometry data form
        /// </summary>
        public string AddButtonData
        {
            get { return (string) GetValue(AddButtonDataProperty); }
            set { SetValue(AddButtonDataProperty, value); }
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
    }
}
