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

namespace prac_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm;
        public MainWindow()
        {
            vm = new prac_10.VM();
            InitializeComponent();
            DataContext = vm;
            vm.Filereader();
            
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.Winnumber(listBox.SelectedItem.ToString());
        }
    }
}
