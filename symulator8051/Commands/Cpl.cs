using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class xB2 : ICommand //CPL bit addr
    {
        I8051 i;

        private byte cycles = 1;
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
        public xB2(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            if (0 < arg || arg < 255)
            {
                if (arg <= 127)
                {
                    if (i.EXT_RAM[arg / 8 + 0x20].chkBit(arg % 8))
                    {
                        i.EXT_RAM[arg / 8 + 0x20] = i.EXT_RAM[arg / 8 + 0x20].clrBit(arg % 8);
                    }
                    else
                    {
                        i.EXT_RAM[arg / 8 + 0x20] = i.EXT_RAM[arg / 8 + 0x20].setBit(arg % 8);
                    }
                }
                else
                {
                    if (i.EXT_RAM[arg - (arg % 8)].chkBit(arg % 8))
                    {
                        i.EXT_RAM[arg - (arg % 8)] = i.EXT_RAM[arg - (arg % 8)].clrBit(arg % 8);
                    }
                    else
                    {
                        i.EXT_RAM[arg - (arg % 8)] = i.EXT_RAM[arg - (arg % 8)].setBit(arg % 8);
                    }
                }
            }
        }
    }
    class xB3 : ICommand //CPL C
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
        private byte arg;
        public xB3( I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (Convert.ToInt16(i.CY) == 1)
                i.PSW = i.PSW.clrBit(bits.bit7);
            else
                i.PSW = i.PSW.setBit(bits.bit7);
        }
    }
    class xF4 : ICommand //CPL A
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
        private byte arg;
        public xF4(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(~i.ACC);
        }
    }
}