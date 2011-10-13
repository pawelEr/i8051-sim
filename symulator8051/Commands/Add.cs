using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x24 : ICommand //ADD A, #data
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
        public x24(I8051 i, byte arg )
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.SFR[arg]);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.SFR[arg] & 0x0f) > 0x0f)
             ByteHelper.setBit(6,1);
            if ((i.ACC & 0x7f) + (i.SFR[arg] & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if ( ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2,1);
                else
                    ByteHelper.setBit(2,0);
            }
            i.ACC=(byte)temp;
        }
    }
    class x25 : ICommand //ADD A, iram addr
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
        public x25(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + arg);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (arg & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (arg & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x26 : ICommand //ADD A, @R0
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
   
        public x26(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.EXT_RAM[i.R0]);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.EXT_RAM[i.R0] & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.EXT_RAM[i.R0] & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }

    class x27 : ICommand //ADD A, @R1
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
        
        public x27(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.EXT_RAM[i.R1]);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.EXT_RAM[i.R1] & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.EXT_RAM[i.R1] & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x28 : ICommand //ADD A, R0
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
     
        public x28(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R0);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R0 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R0 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x29 : ICommand //ADD A, R1
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
       
        public x29(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R1);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R1 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R1 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2A : ICommand //ADD A, R2
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
        
        public x2A(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R2);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R2 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R2 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2B : ICommand //ADD A, R3
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
        
        public x2B(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R3);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R3 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R3 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2C : ICommand //ADD A, R4
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
     
        public x2C(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R4);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R4 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R4 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2D : ICommand //ADD A, R5
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
        
        public x2D(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R5);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R5 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R5 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2E : ICommand //ADD A, R6
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
       
        public x2E(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R6);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R6 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R6 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
        }
    }
    class x2F : ICommand //ADD A, R7
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
      
        public x2F(I8051 i)
        {
            this.i = i;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.ACC + i.R7);
            ByteHelper.clrBit(7, 0);
            ByteHelper.clrBit(2, 0);
            ByteHelper.clrBit(6, 0);
            if ((i.ACC & 0x0f) + (i.R7 & 0x0f) > 0x0f)
                ByteHelper.setBit(6, 1);
            if ((i.ACC & 0x7f) + (i.R7 & 0x7f) > 0x7f)
                ByteHelper.setBit(2, 1);
            if (temp > 0xff)
            {
                ByteHelper.setBit(7, 1);
                if (ByteHelper.chkBit(2, 0))
                    ByteHelper.setBit(2, 1);
                else
                    ByteHelper.setBit(2, 0);
            }
            i.ACC = (byte)temp;
    }
}