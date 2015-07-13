using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class x04 : ICommand //INC A
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
        public x04(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.ACC == 255)
            {
                i.ACC = 0;
            }
            else
            {
                i.ACC++;
            }
        }
    }
    class x05 : ICommand //INC iram addr
    {
        I8051 i;
        private byte cycles = 1;
        private byte arg;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 2;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public x05(byte arg, I8051 i)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.SFR[arg] == 255)
            {
                i.SFR[arg] = 0;
            }
            else
            {
                i.SFR[arg]++;
            }
        }
    }
    class x06 : ICommand //INC @R0
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
        public x06(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R0] == 255)
            {
                i.EXT_RAM[i.R0] = 0;
            }
            else
            {
                i.EXT_RAM[i.R0]++;
            }
        }
    }
    class x07 : ICommand //INC @R0
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
        public x07(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R1] == 255)
            {
                i.EXT_RAM[i.R1] = 0;
            }
            else
            {
                i.EXT_RAM[i.R1]++;
            }
        }
    }
    class x08 : ICommand //INC R0
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
        public x08(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R0 == 255)
            {
                i.R0 = 0;
            }
            else
            {
                i.R0++;
            }
        }
    }
    class x09 : ICommand //INC R1
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
        public x09(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R1 == 255)
            {
                i.R1 = 0;
            }
            else
            {
                i.R1++;
            }
        }
    }
    class x0A : ICommand //INC R2
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
        public x0A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R2 == 255)
            {
                i.R2 = 0;
            }
            else
            {
                i.R2++;
            }
        }
    }
    class x0B : ICommand //INC R3
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
        public x0B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R3 == 255)
            {
                i.R3 = 0;
            }
            else
            {
                i.R3++;
            }
        }
    }
    class x0C : ICommand //INC R4
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
        public x0C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R4 == 255)
            {
                i.R4 = 0;
            }
            else
            {
                i.R4++;
            }
        }
    }
    class x0D : ICommand //INC R5
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
        public x0D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R5 == 255)
            {
                i.R5 = 0;
            }
            else
            {
                i.R5++;
            }
        }
    }
    class x0E : ICommand //INC R6
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
        public x0E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R6 == 255)
            {
                i.R6 = 0;
            }
            else
            {
                i.R6++;
            }
        }
    }
    class x0F : ICommand //INC R7
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
        public x0F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R7 == 255)
            {
                i.R7 = 0;
            }
            else
            {
                i.R7++;
            }
        }
    }
    class xA3 : ICommand //INC DPTR
    {
        I8051 i;
        private byte cycles = 2;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xA3(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.DPTR == 65535)
            {
                i.DPTR = 0;
            }
            else
            {
                i.DPTR++;
            }
        }
    }
}
