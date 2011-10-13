using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace symulator8051
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        I8051 i8051;
        public Main()
        {
            
            InitializeComponent();
            i8051 = new I8051();
            MainGrid.DataContext = i8051;
            
        }
        private void OpenFile(object sender, RoutedEventHandler e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == true)
            {
                SourceCode s = new SourceCode();
                s.FilePath=o.FileName;
                s.Open();
                s.Load(i8051.EXT_PMEM);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            i8051.process();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            i8051.stop();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            i8051.pause();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            i8051.step();
        }
    }
}
