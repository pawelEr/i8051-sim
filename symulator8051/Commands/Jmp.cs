using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class x73 : ICommand //JMP @A+DPTR
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        
        public x73(I8051 i)
        {
            this.i = i;           
        }
        public void execute()
        {
            i.PC =(ushort)( i.ACC + i.DPTR);
        }
    }
}