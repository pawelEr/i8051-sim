using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class xC3
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        public xC3(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.PSW = i.PSW.clrBit(bits.bit8);
        }
    }
    class xE4
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        public xE4(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = 0x00;
        }
    }
}
