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
            try{
                RawLines = File.ReadAllLines(FilePath);
            }
            catch(PathTooLongException)
            {
                MessageBox.Show("Ścieżka do pliku jest za długa.");
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Nieprawidłowa ścieżka.");
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Pliku nie znaleziono.");
            }
            catch(IOException)
            {
                MessageBox.Show("Błąd I/O");
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Nieautoryzowany dostęp");
            };

        }
        public void Load(MemoryRecord[] DestinationMemory)
        {
            foreach(string s in RawLines)
            {
                byte p=Convert.ToByte(s.Substring(0,2));//ilosc par hex na linie
                ushort memInjectAdress=Convert.ToUInt16(s.Substring(2,4));
                byte recordType=Convert.ToByte(s.Substring(6,2));
                for (int i=0; i<=p;i++)
                {
                    DestinationMemory[memInjectAdress+i].Data=Convert.ToByte(s.Substring(i*2,2));
                }
            }
        }
        
    }

}
