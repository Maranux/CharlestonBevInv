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

namespace CBevInc.Pages
{
    /// <summary>
    /// Interaction logic for AnaPage.xaml
    /// </summary>
    public partial class AnaPage : Page
    {
        public AnaPage()
        {
            InitializeComponent();
        }

        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).navHome();
        }
    }
}
