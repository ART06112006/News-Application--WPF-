﻿using NewsApp.ViewModels;
using System;
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
using System.Windows.Shapes;

namespace NewsApp.Views
{
    /// <summary>
    /// Interaction logic for ShowArticleView.xaml
    /// </summary>
    public partial class ShowArticleView : Window
    {
        public ShowArticleViewModel ViewModel { get; set; }
        public ShowArticleView(ShowArticleViewModel showArticleView)
        {
            InitializeComponent();
            ViewModel = showArticleView;
            DataContext = ViewModel;
        }
    }
}
