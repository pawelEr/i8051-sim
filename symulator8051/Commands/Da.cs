using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class xD4 : ICommand //DA A
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
        public xD4(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.ACC == 1 || ((i.ACC & 0x0f) >> 8) > 0x09)
            {
                UInt16 val = (UInt16)(i.ACC + 0x06);
                if (val > 0xff)
                    i.PSW = i.PSW.setBit(bits.bit7);
                i.ACC = (byte)val;
            }
            if (Convert.ToByte(i.CY) == 1 || ((i.ACC & 0xf0) >> 8) > 0x09)
            {
                UInt16 val = (UInt16)(i.ACC + 0x06);
                if (val > 0xff)
                    i.PSW = i.PSW.setBit(bits.bit7);
                i.ACC = (byte)val;
            }

        }
    }
}