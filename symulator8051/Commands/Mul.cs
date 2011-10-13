using System;
using System.Collections.Generic;
using System.Linq;
using ByteExtensionMethods;
using System.Text;

namespace symulator8051.Commands
{
    class xA4 : ICommand //MUL AB
    {
        I8051 i;
        private byte cycles = 4;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xA4(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC * i.B);
            ByteHelper.clrBit(7, 0);
            if (temp > 0xff)
                ByteHelper.setBit(2, 1);
            else
                ByteHelper.clrBit(2, 0);
            i.ACC = (byte)(temp & 0x00ff);
            i.B = (byte)((temp & 0xff00) >> 8);
        }
    }
}