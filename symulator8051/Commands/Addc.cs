using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class x34 : ICommand //ADDC A, #data
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
        public x34(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.SFR[arg]);
        }
    }
    class x35 : ICommand //ADDC A, iram addr
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
        public x35(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + arg);
        }
    }
    class x36 : ICommand //ADDC A, @R0
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

        public x36(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.EXT_RAM[i.R0]);
        }
    }

    class x37 : ICommand //ADDC A, @R1
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

        public x37(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.EXT_RAM[i.R1]);
        }
    }
    class x38 : ICommand //ADDC A, R0
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

        public x38(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R0);
        }
    }
    class x39 : ICommand //ADDC A, R1
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

        public x39(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R1);
        }
    }
    class x3A : ICommand //ADDC A, R2
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

        public x3A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R2);
        }
    }
    class x3B : ICommand //ADDC A, R3
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

        public x3B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R3);
        }
    }
    class x3C : ICommand //ADDC A, R4
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

        public x3C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R4);
        }
    }
    class x3D : ICommand //ADDC A, R5
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

        public x3D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R5);
        }
    }
    class x3E : ICommand //ADDC A, R6
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

        public x3E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R6);
        }
    }
    class x3F : ICommand //ADDC A, R7
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

        public x3F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R7);
        }
    }
}