using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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
        /// Items to display in the selected items list box
        /// </summary>
        public IEnumerable<ISelectiveListItem> SelectedItems
        {
            get { return (IEnumerable<ISelectiveListItem>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
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
            RemoveAllCommand = new RelayCommand(ExecuteRemoveAllCommand, CanExecuteRemoveAllCommand);
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
