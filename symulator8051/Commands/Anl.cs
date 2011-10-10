using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class x52 : ICommand //ANL iram addr, A
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
        public x52(byte arg, I8051 i)
        {
            this.arg=arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (i.ACC & i.SFR[arg]);
        }
    }

    class x53 : ICommand //ANL iram addr, #data
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
        public x53(byte arg2, byte arg, I8051 i)
        {
            this.arg2 = arg2;
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (arg2 & i.SFR[arg]);
        }
    }

    class x54 : ICommand //ANL A, #data
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
        public x54(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (i.ACC & arg);
        }
    }

    class x55 : ICommand //ANL A, iram addr
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
        public x55(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.SFR[arg]);
        }
    }

    class x56 : ICommand //ANL A,@R0
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
        public x56(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.EXT_RAM[i.R0]);
        }
    }

    class x57 : ICommand //ANL A,@R1
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
        public x57(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.EXT_RAM[i.R1]);
        }
    }

    class x58 : ICommand //ANL A,R0
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
        public x58(I8051 i)
        {
            this.i=i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R0);
        }
    }

    class x59 : ICommand //ANL A,R1
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
        public x59(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R1);
        }
    }

    class x5A : ICommand //ANL A,R2
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
        public x5A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R2);
        }
    }

    class x5B : ICommand //ANL A,R3
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
        public x5B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R3);
        }
    }

    class x5C : ICommand //ANL A,R4
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
        public x5C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R4);
        }
    }

    class x5D : ICommand //ANL A,R5
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
        public x5D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R5);
        }
    }

    class x5E : ICommand //ANL A,R6
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
        public x5E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R6);
        }
    }

    class x5F : ICommand //ANL A,R7
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
        public x5F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (i.ACC & i.R7);
        }
    }
}