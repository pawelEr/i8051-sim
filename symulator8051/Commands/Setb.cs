using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class xD2 : ICommand
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private byte arg;
        public xD2(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.EXT_RAM[arg] = 1;
        }

        private ushort bytes = 2;
        public ushort Bytes
        {
            get { return bytes; }
        }
    }
    class xD3 : ICommand
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        public xD3(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.PSW = i.PSW.setBit(bits.bit7);
        }

        private ushort bytes = 2;
        public ushort Bytes
        {
            get { return bytes; }
        }
    }
}