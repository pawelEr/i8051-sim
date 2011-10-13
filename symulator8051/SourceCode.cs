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

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
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
        public void Load(MemoryRecord[] DestinationMemory)
        {
            foreach(string s in RawLines)
            {
                byte p=Convert.ToByte(s.Substring(1,2),16);//ilosc par hex na linie
                ushort memInjectAdress=Convert.ToUInt16(s.Substring(3,4),16);
                byte recordType=Convert.ToByte(s.Substring(7,2),16);
                if (recordType == 00)
                {
                    for (int i = 0; i <= p; i++)
                    {
                        DestinationMemory[memInjectAdress + i].Data = Convert.ToByte(s.Substring(8 + i * 2, 2), 16);
                    }
                }
                else if (recordType == 01)
                {
 
                }
            }
        }
        
    }

}
