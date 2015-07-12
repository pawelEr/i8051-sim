using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace symulator8051
{

	class SourceCode
	{
		public static string code = null;
		private string[] RawLines;
		private string filePath;

		private bool anyCodeLoaded = false;

		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}

		public bool isThereAnyCode
		{
			get { return anyCodeLoaded; }
		}

		public SourceCode()
		{
		}
		public void Open()
		{
			try
			{
				RawLines = File.ReadAllLines(FilePath);
			}
			catch (PathTooLongException)
			{
				MessageBox.Show("Ścieżka do pliku jest za długa.");
			}
			catch (DirectoryNotFoundException)
			{
				MessageBox.Show("Nieprawidłowa ścieżka.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Pliku nie znaleziono.");
			}
			catch (IOException)
			{
				MessageBox.Show("Błąd I/O");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Nieautoryzowany dostęp");
			};
		}
		public void Load(MemoryRecord[] DestinationMemory) //funkcja parsuje plik hex i wczytuje do pamięci układu
		{
			foreach (string s in RawLines)
			{
				byte p = Convert.ToByte(s.Substring(1, 2), 16); //ilosc par hex na linie
				ushort memInjectAdress = Convert.ToUInt16(s.Substring(3, 4), 16); //miejce w pamięci w którym ma być wpisana dana linia kodu
				byte recordType = Convert.ToByte(s.Substring(7, 2), 16); //typ rekordu 
				if (recordType == 00) //rekordy ze zwykłym kodem maszynowym
				{
					for (int i = 0; i <= p; i++)
					{
						DestinationMemory[memInjectAdress + i].Data = Convert.ToByte(s.Substring(9 + i * 2, 2), 16);
					}
					anyCodeLoaded = true;
				}
				else if (recordType == 01) //rekord z końcem kodu
				{

				}
				//02 - kod maszynowy dla pamięci zewnętrznej (nieobsługiwany)
			}
		}

	}

}
