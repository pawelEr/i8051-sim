using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class xB4 : ICommand //CJNE A, #data, code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB4(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.ACC != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xB5 : ICommand //CJNE A, iram addr, code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB5(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.ACC != arg)
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < arg)
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xB6 : ICommand //CJNE @R0,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB6(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.EXT_RAM[i.R0] != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }

    class xB7 : ICommand //CJNE @R1,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB7(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.EXT_RAM[i.R1] != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xB8 : ICommand //CJNE R0,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB8(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R0 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xB9 : ICommand //CJNE R1,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xB9(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R1 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBA : ICommand //CJNE R2,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBA(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R2 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBB : ICommand //CJNE R3,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBB(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R3 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBC : ICommand //CJNE R4,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBC(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R4 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBD : ICommand //CJNE R5,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBD(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R5 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBE : ICommand //CJNE R6,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBE(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R6 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xBF : ICommand //CJNE R7,#data,code addr
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 3;
        public ushort Bytes
        {
            get { return bytes; }
        }
        private byte arg;
        private byte arg2;
        public xBF(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg;
        }
        public void execute()
        {
            
            if (i.R7 != i.SFR[arg])
                i.PC = Convert.ToUInt16(i.PC + arg2);
            if (i.ACC < i.SFR[arg])
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
}