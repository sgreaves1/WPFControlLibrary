using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MyLibrary.Command;
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
                new PropertyMetadata(null, AvailableItemsChanged));

        /// <summary>
        /// Dependency Property for the <see cref="AvailibleItemsCount"/> property.
        /// </summary>
        public static readonly DependencyProperty AvailibleItemsCountProperty =
            DependencyProperty.Register("AvailibleItemsCount", 
                typeof(int), 
                typeof(SelectiveListUc), 
                new PropertyMetadata(0));

        /// <summary>
        /// Dependency property for the <see cref="SelectedItems"/> property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems",
                typeof(IEnumerable<ISelectiveListItem>),
                typeof(SelectiveListUc),
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency Property for the <see cref="SelectedItemsCount"/> property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsCountProperty =
            DependencyProperty.Register("SelectedItemsCount",
                typeof(int),
                typeof(SelectiveListUc),
                new PropertyMetadata(0));

        /// <summary>
        /// Dependency Property for the <see cref="Colour"/> property.
        /// </summary>
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Colour", 
                typeof(Brush), 
                typeof(SelectiveListUc),
                new PropertyMetadata(Brushes.Black));
        
        /// <summary>
        /// Constructor
        /// </summary>
        public SelectiveListUc()
        {
            InitializeComponent();

            InitCommands();
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
        /// Stores the total number of available items
        /// </summary>
        public int AvailibleItemsCount
        {
            get { return (int)GetValue(AvailibleItemsCountProperty); }
            set { SetValue(AvailibleItemsCountProperty, value); }
        }

        /// <summary>
        /// Items to display in the selected items list box
        /// </summary>
        public IEnumerable<ISelectiveListItem> SelectedItems
        {
            get { return (IEnumerable<ISelectiveListItem>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
                SelectedItemsCount = SelectedItems.Count();
            }
        }

        /// <summary>
        /// Stores the total number of selected items
        /// </summary>
        public int SelectedItemsCount
        {
            get { return (int)GetValue(SelectedItemsCountProperty); }
            set { SetValue(SelectedItemsCountProperty, value); }
        }

        /// <summary>
        /// The colour of this selective list control
        /// </summary>
        public Brush Colour
        {
            get { return (Brush)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        /// <summary>
        /// Fires when available items changes
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="dependencyPropertyChangedEventArgs"></param>
        private static void AvailableItemsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            SelectiveListUc uc = (SelectiveListUc)dependencyObject;

            uc.AvailibleItemsCount = uc.AvailibleItems.Count();
        }

        #region Commands
        public ICommand AddAllCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand RemoveAllCommand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void InitCommands()
        {
            AddAllCommand = new RelayCommand(ExecuteAddAllCommand, CanExecuteAddAllCommand);
            AddCommand = new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
            RemoveCommand = new RelayCommand(ExecuteRemoveCommand, CanExecuteCanExecuteRemoveCommand);
            RemoveAllCommand = new RelayCommand(ExecuteRemoveAllCommand, CanExecuteRemoveAllCommand);
        }

        private bool CanExecuteCanExecuteRemoveCommand()
        {
            if (SelectedListBox.SelectedItems.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void ExecuteRemoveCommand()
        {
            var availible = AvailibleItems.ToList();
            var selected = SelectedItems.ToList();

            foreach (var selectedItem in SelectedListBox.SelectedItems)
            {
                selected.Remove((ISelectiveListItem)selectedItem);
                availible.Add((ISelectiveListItem)selectedItem);
            }

            AvailibleItems = availible;
            SelectedItems = selected;
        }

        private bool CanExecuteAddCommand()
        {
            if (AvailibleListBox.SelectedItems.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void ExecuteAddCommand()
        {
            var availible = AvailibleItems.ToList();
            var selected = SelectedItems.ToList();

            foreach (var selectedItem in AvailibleListBox.SelectedItems)
            {
                availible.Remove((ISelectiveListItem) selectedItem);
                selected.Add((ISelectiveListItem)selectedItem);
            }

            AvailibleItems = availible;
            SelectedItems = selected;
        }

        private bool CanExecuteAddAllCommand()
        {
            if (AvailibleItems != null && AvailibleItems.Any())
            {
                return true;
            }

            return false;
        }

        private void ExecuteAddAllCommand()
        {
            if (AvailibleItems != null)
            {
                if (SelectedItems != null)
                {
                    var selected = SelectedItems.ToList();
                    selected.AddRange(AvailibleItems);
                    SelectedItems = selected;


                    var availible = AvailibleItems.ToList();
                    availible.Clear();
                    AvailibleItems = availible;
                }
            }
        }

        private bool CanExecuteRemoveAllCommand()
        {
            if (SelectedItems != null && SelectedItems.Any())
            {
                return true;
            }

            return false;
        }

        private void ExecuteRemoveAllCommand()
        {
            if (SelectedItems != null)
            {
                if (AvailibleItems != null)
                {
                    var availible = AvailibleItems.ToList();
                    availible.AddRange(SelectedItems);
                    AvailibleItems = availible;


                    var selected = SelectedItems.ToList();
                    selected.Clear();
                    SelectedItems = selected;
                }
            }
        }

        #endregion
    }
}
