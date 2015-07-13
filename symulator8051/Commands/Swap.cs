using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class xC4 : ICommand //SWAP A
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xC4(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)((i.ACC << 4) | (i.ACC >> 4));
        }
    }
}