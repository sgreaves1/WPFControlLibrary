﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibrarySamples.Pages.SelectiveList.ViewModel;

namespace LibrarySamples.Pages.SelectiveList
{
    /// <summary>
    /// Interaction logic for SelectiveListPage.xaml
    /// </summary>
    public partial class SelectiveListPage : Page
    {
        public SelectiveListPage()
        {
            InitializeComponent();

            DataContext = new SelectiveListViewModel();
        }
    }
}
