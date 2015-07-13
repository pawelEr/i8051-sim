using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using symulator8051.Sim;

namespace symulator8051
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : Window, INotifyPropertyChanged
	{

		private SimulationController simulationController;

		public event PropertyChangedEventHandler PropertyChanged;
		String FileName;


		public Main()
		{
			InitializeComponent();
			simulationController = new SimulationController(new lcdControler(lcdControl1, lcdControl2, lcdControl3, lcdControl4));

			this.DataContext = simulationController.GuiDataValues;
			simulationController.GuiDataValues.UpdateFields();

			//memoryPreview.ItemsSource = guiData.EXT_RAM;
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e) //otworz
		{
			OpenFileDialog o = new OpenFileDialog();
			o.DefaultExt = "*.asm";
			if (o.ShowDialog() == true)
			{
				this.FileName = o.FileName;
				simulationController.GuiDataValues.RawSourceCode = File.ReadAllText(this.FileName);
			}
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e) //uruchom
		{
			if (simulationController.StartSimulation())
			{
				menuFile.IsEnabled = false;
				menuSettings.IsEnabled = false;
				menuRun.IsEnabled = false;
				menuStop.IsEnabled = true;
				menuPause.IsEnabled = true;
				menuNextStep.IsEnabled = false;
				IsEditorEnabled(false);
			}
		}

		private void MenuItem_Click_2(object sender, RoutedEventArgs e) //stop
		{
			simulationController.StopSimulation();
			menuFile.IsEnabled = true;
			menuSettings.IsEnabled = true;
			menuRun.IsEnabled = true;
			menuStop.IsEnabled = false;
			menuPause.IsEnabled = false;
			menuNextStep.IsEnabled = false;
			IsEditorEnabled(true);
		}

		private void MenuItem_Click_3(object sender, RoutedEventArgs e) //pauza
		{
			menuFile.IsEnabled = false;
			menuSettings.IsEnabled = false;
			menuRun.IsEnabled = true;
			menuStop.IsEnabled = true;
			menuPause.IsEnabled = false;
			menuNextStep.IsEnabled = true;
			simulationController.PauseSimulation();
		}

		private void MenuItem_Click_4(object sender, RoutedEventArgs e) //nastepny krok
		{
			simulationController.SimulationNextStep();
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
			simulationController.GuiDataValues.RawSourceCode = null;
		}

		private void MenuItem_Click_12(object sender, RoutedEventArgs e) //zapisz
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = this.FileName;
			if (sfd.ShowDialog() == true)
			{
				File.WriteAllText(sfd.FileName, simulationController.GuiDataValues.RawSourceCode);
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

		private void onWindowClose(object sender, CancelEventArgs e)
		{
			simulationController.StopSimulation();
		}

		private void IsEditorEnabled(bool enabled)
		{
			CodeTbox.IsEnabled = enabled;
			EditorBackButton.IsEnabled = enabled;
			EditorRedoButton.IsEnabled = enabled;
			EditorCopyButton.IsEnabled = enabled;
			EditorCutButton.IsEnabled = enabled;
			EditorPasteButton.IsEnabled = enabled;
		}
	}
}
