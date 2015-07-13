using System;

namespace symulator8051.Sim.Commands
{
    class xD5 : ICommand //DJNZ data addr, code addr
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
        public xD5(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg2;
        }
        public void execute()
        {
            byte addrRAM = i.EXT_RAM[arg];
            sbyte addrJmp = (sbyte)(i.EXT_RAM[arg2]);
            i.EXT_RAM[addrRAM] = (byte)(i.EXT_RAM[addrRAM] - 1);
            if (i.EXT_RAM[addrRAM] != 0)
                i.PC = (UInt16)(i.PC + addrJmp);
        }
    }
    class xD8 : ICommand //DJNZ R0, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xD8(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R0] != 0)
                i.PC =(UInt16)( i.PC + arg);
        }
    }
    class xD9 : ICommand //DJNZ R1, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xD9(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R1] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDA : ICommand //DJNZ R2, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDA(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R2] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDB : ICommand //DJNZ R3, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDB(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R3] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDC : ICommand //DJNZ R4, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDC(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R4] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDD : ICommand //DJNZ R5, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDD(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R5] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDE : ICommand //DJNZ R6, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDE(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R6] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
    class xDF : ICommand //DJNZ R7, code addr
    {
        I8051 i;
        private byte cycles = 2;
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
        public xDF(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R7] != 0)
                i.PC = (UInt16)(i.PC + arg);
        }
    }
}