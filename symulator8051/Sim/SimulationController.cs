using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace symulator8051.Sim
{
	class SimulationController
	{
		private I8051 i8051;
		private GuiDataValues guiData;

		public GuiDataValues GuiDataValues
		{
			get { return guiData; }
		}

		public SimulationController(lcdControler lcdControler)
		{
			i8051 = new I8051();
			lcdControler.I8051 = i8051;
			guiData =  new GuiDataValues(i8051,  lcdControler);
		}

		public bool StartSimulation()
		{
			if (File.Exists(@"temp.hex"))
				File.Delete(@"temp.hex");
			try
			{
				File.WriteAllText(@"temp.asm", "$NOMOD51\n$INCLUDE (8051.MCU)\n" + guiData.RawSourceCode);
			}
			catch (IOException e)
			{
				MessageBox.Show("Bład przy zapisie pliku tymczasowego.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			int processExitCode = 0;
			try
			{
				Process p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.StartInfo.RedirectStandardInput = true;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.FileName = @"ASEMW.exe";
				p.StartInfo.Arguments = " temp.asm";
				//p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
				p.Start();
				guiData.Output = p.StandardOutput.ReadToEnd();
				p.WaitForExit();
				processExitCode = p.ExitCode;
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Błąd nie znaleziono ASM51.exe w katalogu programu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (Win32Exception)
			{
				MessageBox.Show("Do poprawnego działania programu ASM51.exe wymagany jest 32 bitowy system.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			if (processExitCode != 0) return false;
			if (File.Exists(@"temp.hex"))
			{

				SourceCode s = new SourceCode();
				s.FilePath = @"temp.hex";
				s.Open();
				s.Load(i8051.EXT_PMEM);
				if (s.isThereAnyCode)
				{
					guiData.StartUpdate();
					i8051.process();
					return true;
				}
				else
				{
					MessageBox.Show("Symulacji nie uruchomiono z powodu braku czegokolwiek do symulowania", "Info",
						MessageBoxButton.OK, MessageBoxImage.Information);
				}

			}
			else
			{
				MessageBox.Show("Podczas przetwarzania kodu źródłowego wystąpił bład.", "Błąd", MessageBoxButton.OK,
					MessageBoxImage.Error);
			}

			return false;

		}

		public void StopSimulation()
		{
			i8051.stop();
			guiData.StopUpdate();
			guiData.UpdateFields();
		}

		public void PauseSimulation()
		{
			i8051.pause();
			guiData.StopUpdate();
			guiData.UpdateFields();
		}

		public void SimulationNextStep()
		{
			i8051.step();
			guiData.UpdateFields();
		}

	}
}
