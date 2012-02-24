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
using System.Windows.Forms.Integration;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using DmitryBrant.CustomControls;
using System.Diagnostics;
using System.Threading;

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
        public string output;
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
            guiData = new GuiDataValues(i8051, this);

            MainGrid.DataContext = guiData;
            CodeTbox.DataContext = this;
            guiData.UpdateFields();

            //memoryPreview.ItemsSource = guiData.EXT_RAM;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //otworz
        {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultExt = "*.asm";
            if (o.ShowDialog() == true)
            {
                this.FileName = o.FileName;
                RawSourceCode = File.ReadAllText(this.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //uruchom
        {
            //TODO: zablokować część interfejsu
            File.WriteAllText(@"temp.asm", "$MOD51\n" + this.rawSourceCode);


            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = @"ASM51.exe";
                p.StartInfo.Arguments = " temp.asm";
                //p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.Start();
                this.output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Błąd nie znaleziono ASM51.exe w katalogu programu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                menu.IsEnabled = true;
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Do poprawnego działania programu ASM51.exe wymagany jest 32 bitowy system.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                menu.IsEnabled = true;
            }

            if (File.Exists(@"c:\asm\temp.hex") == true)
            {

                SourceCode s = new SourceCode();
                s.FilePath = @"c:\asm\temp.hex";
                s.Open();
                s.Load(i8051.EXT_PMEM);
                guiData.StartUpdate();
                i8051.process();

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //stop
        {
            i8051.stop();
            guiData.StopUpdate();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //pauza
        {
            menuPause.IsEnabled = false;
            menuNextStep.IsEnabled = true;
            i8051.pause();
            guiData.StopUpdate();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) //nastepny krok
        {
            i8051.step();
            guiData.UpdateFields();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e) //ustawienia
        {
            Settings f = new Settings();
            f.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            f.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e) //wstecz (edytor)
        {
            this.CodeTbox.Undo();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e) //dalej (edytor)
        {
            this.CodeTbox.Redo();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e) //kopiuj (edytor)
        {
            this.CodeTbox.Copy();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e) //wytnij (edytor)
        {
            this.CodeTbox.Cut();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e) //wklej (edytor)
        {
            this.CodeTbox.Paste();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e) //nowy
        {
            this.FileName = null;
            this.rawSourceCode = null;
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e) //zapisz
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = this.FileName;
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, this.rawSourceCode);
            }
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e) //zamknij
        {
            Application.Current.Shutdown();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
