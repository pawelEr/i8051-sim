using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class x62 : ICommand //XRL iram addr, A
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
        public x62(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (byte)(i.ACC ^ i.SFR[arg]);
        }
    }

    class x63 : ICommand //XRL iram addr, #data
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
        public x63(byte arg2, byte arg, I8051 i)
        {
            this.arg2 = arg2;
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (byte)(arg2 ^ i.SFR[arg]);
        }
    }

    class x64 : ICommand //XRL A, #data
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
        public x64(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ arg);
        }
    }

    class x65 : ICommand //XRL A, iram addr
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
        public x65(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.SFR[arg]);
        }
    }

    class x66 : ICommand //XRL A,@R0
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
        public x66(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.EXT_RAM[i.R0]);
        }
    }

    class x67 : ICommand //XRL A,@R1
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
        public x67(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.EXT_RAM[i.R1]);
        }
    }

    class x68 : ICommand //XRL A,R0
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
        public x68(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R0);
        }
    }

    class x69 : ICommand //XRL A,R1
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
        public x69(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R1);
        }
    }

    class x6A : ICommand //XRL A,R2
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
        public x6A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R2);
        }
    }

    class x6B : ICommand //XRL A,R3
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
        public x6B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R3);
        }
    }

    class x6C : ICommand //XRL A,R4
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
        public x6C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R4);
        }
    }

    class x6D : ICommand //XRL A,R5
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
        public x6D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R5);
        }
    }

    class x6E : ICommand //XRL A,R6
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
        public x6E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R6);
        }
    }

    class x6F : ICommand //XRL A,R7
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
        public x6F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC ^ i.R7);
        }
    }
}