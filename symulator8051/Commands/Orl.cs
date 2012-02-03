using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x42 : ICommand //ORL iram addr, A
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
        public x42(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (byte)(i.ACC | i.SFR[arg]);
        }
    }

    class x43 : ICommand //ORL iram addr, #data
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
        public x43(byte arg2, byte arg, I8051 i)
        {
            this.arg2 = arg2;
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = (byte)(arg2 | i.SFR[arg]);
        }
    }

    class x44 : ICommand //ORL A, #data
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
        public x44(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | arg);
        }
    }

    class x45 : ICommand //ORL A, iram addr
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
        public x45(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.SFR[arg]);
        }
    }

    class x46 : ICommand //ORL A,@R0
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
        public x46(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.EXT_RAM[i.R0]);
        }
    }

    class x47 : ICommand //ORL A,@R1
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
        public x47(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.EXT_RAM[i.R1]);
        }
    }

    class x48 : ICommand //ORL A,R0
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
        public x48(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R0);
        }
    }

    class x49 : ICommand //ORL A,R1
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
        public x49(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R1);
        }
    }

    class x4A : ICommand //ORL A,R2
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
        public x4A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R2);
        }
    }

    class x4B : ICommand //ORL A,R3
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
        public x4B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R3);
        }
    }

    class x4C : ICommand //ORL A,R4
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
        public x4C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R4);
        }
    }

    class x4D : ICommand //ORL A,R5
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
        public x4D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R5);
        }
    }

    class x4E : ICommand //ORL A,R6
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
        public x4E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R6);
        }
    }

    class x4F : ICommand //ORL A,R7
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
        public x4F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = (byte)(i.ACC | i.R7);
        }
    }
    class x72 : ICommand //ORL C,bit
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
        public x72(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if ((i.CY) | (arg) == 1)
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
    class xA0 : ICommand //ORL C,~bit
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
        public xA0(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if ((i.CY) | (~arg) == 1)
                i.PSW = i.PSW.setBit(bits.bit7);
            else
                i.PSW = i.PSW.clrBit(bits.bit7);
        }
    }
}