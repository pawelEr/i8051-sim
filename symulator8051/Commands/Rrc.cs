using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x13 : ICommand //RRC A
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
        public x13(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            byte b0 = (i.ACC);
            i.ACC = (byte)((i.ACC >> 1) | (Convert.ToByte(i.CY) << 7));
            if (b0 == 1)
                ByteHelper.setBit(1, 7);
            else
                ByteHelper.clrBit(0, 7);
        }
    }
}