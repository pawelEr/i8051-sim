using System;

namespace symulator8051.Sim.Commands
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
            i.PSW = i.PSW.clrBit(bits.bit7);
            if (temp > 0xff)
                i.PSW = i.PSW.setBit(bits.bit2);
            else
                i.PSW = i.PSW.clrBit(bits.bit2);
            i.ACC = (byte)(temp & 0x00ff);
            i.B = (byte)((temp & 0xff00) >> 8);
        }
    }
}