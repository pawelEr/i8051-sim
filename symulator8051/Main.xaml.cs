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
using System.IO;
using System.ComponentModel;

namespace symulator8051
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window, INotifyPropertyChanged
    {
        I8051 i8051;
        GuiDataValues guiData;
        private string rawSourceCode;
        public event PropertyChangedEventHandler PropertyChanged;
        String FileName;
        public string RawSourceCode
        {
            get { return rawSourceCode; }
            set
            {
                rawSourceCode = value;
                OnPropertyChanged("RawSourceCode");
            }
        }
        public Main()
        {
            
            InitializeComponent();
            i8051 = new I8051();
            guiData = new GuiDataValues(i8051);
            
            MainGrid.DataContext = guiData;
            CodeTbox.DataContext = this;
            guiData.UpdateFields();memoryPreview.ItemsSource = guiData.EXT_RAM;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultExt = "*.asm";
            if (o.ShowDialog() == true)
            {
                this.FileName=o.FileName;
                RawSourceCode = File.ReadAllText(this.FileName);             
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SourceCode s = new SourceCode();
            //s.FilePath = o.FileName;
            s.Open();
            s.Load(i8051.EXT_PMEM);
            i8051.process();
            guiData.StartUpdate();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            i8051.stop();
            guiData.StopUpdate();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            i8051.pause();
            guiData.StopUpdate();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            i8051.step();
            guiData.UpdateFields();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Settings f = new Settings();
            f.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            f.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            this.CodeTbox.Undo();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            this.CodeTbox.Redo();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            this.CodeTbox.Copy();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            this.CodeTbox.Cut();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            this.CodeTbox.Paste();
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            this.FileName = null;
            this.rawSourceCode = null;
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = this.FileName;
            if (sfd.ShowDialog()==true)
            {
                File.WriteAllText(sfd.FileName, this.rawSourceCode);    
            }
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
