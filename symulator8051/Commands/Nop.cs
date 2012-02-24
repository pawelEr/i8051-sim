using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{
    class x00 : ICommand
    {
        public byte cycles = 1; //ilosc cykli ktora instrukcja jest wykonywana
        public byte Cycles 
        {
            get{return cycles;} 
        }
        public void execute() //operacje wykonywane przez rozkaz
        {
        }

        private ushort bytes=1; //długość instrukcji
        public ushort Bytes
        {
            get { return bytes; }
        }
    }
}
