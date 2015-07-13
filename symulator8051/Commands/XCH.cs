using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class xC5 : ICommand //XCH A, data addr
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
        public xC5(I8051 i, byte arg)
        {
            this.i = i;
            this.arg=arg;
        }
        private byte temp;
        public void execute()
        {
          temp=i.ACC;
          i.ACC=i.SFR[arg];
          i.SFR[arg]=temp;
        }
    }

    class xC6 : ICommand //XCH A,@R0
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
        public xC6(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.EXT_RAM[i.R0];
            i.EXT_RAM[i.R0] = temp;
        }
    }

    class xC7 : ICommand //XCH A,@R1
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
        public xC7(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.EXT_RAM[i.R1];
            i.EXT_RAM[i.R1] = temp;
        }
    }

    class xC8 : ICommand //XCH A,R0
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
        public xC8(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R0;
            i.R0 = temp;
        }
    }

    class xC9 : ICommand //XCH A,R1
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
        public xC9(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R1;
            i.R1 = temp;
        }
    }

    class xCA : ICommand //XCH A,R2
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
        public xCA(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R2;
            i.R2 = temp;
        }
    }

    class xCB : ICommand //XCH A,R3
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
        public xCB(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R3;
            i.R3 = temp;
        }
    }

    class xCC : ICommand //XCH A,R4
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
        public xCC(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R4;
            i.R4 = temp;
        }
    }

    class xCD : ICommand //XCH A,R5
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
        public xCD(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R5;
            i.R5 = temp;
        }
    }

    class xCE : ICommand //XCH A,R6
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
        public xCE(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R6;
            i.R6 = temp;
        }
    }

    class xCF : ICommand //XCH A,R7
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
        public xCF(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = i.ACC;
            i.ACC = i.R7;
            i.R7 = temp;
        }
    }
}