using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{
    class x00 : ICommand
    {
        public byte cycles = 1;
        public byte Cycles 
        {
            get{return cycles;} 
        }
        public void execute()
        {
        }

        private ushort bytes=1;
        public ushort Bytes
        {
            get { return bytes; }
        }
    }
}
