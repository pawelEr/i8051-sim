using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class x94 : ICommand //SUBB A, #data
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
        public x94(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value=(byte)(i.SFR[arg]+Convert.ToByte(i.CY));
            temp=(UInt16)(i.ACC-value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.SFR[arg] & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.SFR[arg] & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.SFR[arg]>i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x95 : ICommand //SUBB A, iram addr
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
        public x95(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(arg + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((arg & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((arg & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (arg > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x96 : ICommand //SUBB A, @R0
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
       
        public x96(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.EXT_RAM[i.R0] + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.EXT_RAM[i.R0] & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.EXT_RAM[i.R0] & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.EXT_RAM[i.R0] > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }

    class x97 : ICommand //SUBB A, @R1
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
        
        public x97(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.EXT_RAM[i.R1] + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.EXT_RAM[i.R1] & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.EXT_RAM[i.R1] & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.EXT_RAM[i.R1] > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x98 : ICommand //SUBB A, R0
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
        
        public x98(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R0 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R0 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R0 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R0 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x99 : ICommand //SUBB A, R1
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
        
        public x99(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R1 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R1 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R1 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R1 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    
    class x9A : ICommand //SUBB A, R2
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
        
        public x9A(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R2 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R2 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R2 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R2 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x9B : ICommand //SUBB A, R3
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
        
        public x9B(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R3 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R3 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R3 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R3 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x9C : ICommand //SUBB A, R4
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
    
        public x9C(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R4 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R4 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R4 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R4 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x9D : ICommand //SUBB A, R5
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
        
        public x9D(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R5 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R5 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R5 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R5 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x9E : ICommand //SUBB A, R6
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
       
        public x9E(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R6 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R6 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R6 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R6 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
    class x9F : ICommand //SUBB A, R7
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
        
        public x9F(I8051 i)
        {
            this.i = i;
        }
        private byte value;
        private UInt16 temp;
        public void execute()
        {
            value = (byte)(i.R7 + Convert.ToByte(i.CY));
            temp = (UInt16)(i.ACC - value);
            i.PSW = i.PSW.clrBit(bits.bit7);
            i.PSW = i.PSW.clrBit(bits.bit2);
            i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R7 & 0x0f) > (i.ACC & 0x0f))
                i.PSW = i.PSW.setBit(bits.bit6);
            else
                i.PSW = i.PSW.clrBit(bits.bit6);
            if ((i.R7 & 0x7f) > (i.ACC & 0x7f))
                i.PSW = i.PSW.setBit(bits.bit2);
            if (i.R7 > i.ACC)
            {
                i.PSW = i.PSW.setBit(bits.bit7);
                if (i.PSW.chkBit(bits.bit2))
                    i.PSW = i.PSW.setBit(bits.bit2);
                else
                    i.PSW = i.PSW.clrBit(bits.bit2);
            }
        }
    }
}