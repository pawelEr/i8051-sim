using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x80 : ICommand //JB bit,adres
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 2;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        public x80(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.PC =(ushort)( i.PC + arg);
        }
    }
}