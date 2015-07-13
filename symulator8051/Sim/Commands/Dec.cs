namespace symulator8051.Sim.Commands
{
    class x14 : ICommand //DEC A
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
        public x14(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.ACC == 0)
            {
                i.ACC = 255;
            }
            else
            {
                i.ACC--;
            }
        }
    }
    class x15 : ICommand //DEC iram addr
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
        public x15(byte arg, I8051 i)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.SFR[arg] == 0)
            {
                i.SFR[arg] = 255;
            }
            else
            {
                i.SFR[arg]--;
            }
        }
    }
    class x16 : ICommand //DEC @R0
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
        public x16(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R0] == 0)
            {
                i.EXT_RAM[i.R0] = 255;
            }
            else
            {
                i.EXT_RAM[i.R0]--;
            }
        }
    }
    class x17 : ICommand //DEC @R1
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
        public x17(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.EXT_RAM[i.R1] == 0)
            {
                i.EXT_RAM[i.R1] = 255;
            }
            else
            {
                i.EXT_RAM[i.R1]--;
            }
        }
    }
    class x18 : ICommand //DEC R0
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
        public x18(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R0 == 0)
            {
                i.R0 = 255;
            }
            else
            {
                i.R0--;
            }
        }
    }
    class x19 : ICommand //DEC R1
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
        public x19(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R1 == 0)
            {
                i.R1 = 255;
            }
            else
            {
                i.R1--;
            }
        }
    }
    class x1A : ICommand //DEC R2
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
        public x1A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R2 == 0)
            {
                i.R2 = 255;
            }
            else
            {
                i.R2--;
            }
        }
    }
    class x1B : ICommand //DEC R3
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
        public x1B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R3 == 0)
            {
                i.R3 = 255;
            }
            else
            {
                i.R3--;
            }
        }
    }
    class x1C : ICommand //DEC R4
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
        public x1C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R4 == 0)
            {
                i.R4 = 255;
            }
            else
            {
                i.R4--;
            }
        }
    }
    class x1D : ICommand //DEC R5
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
        public x1D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R5 == 0)
            {
                i.R5 = 255;
            }
            else
            {
                i.R5--;
            }
        }
    }
    class x1E : ICommand //DEC R6
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
        public x1E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R6 == 0)
            {
                i.R6 = 255;
            }
            else
            {
                i.R6--;
            }
        }
    }
    class x1F : ICommand //DEC R7
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
        public x1F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            if (i.R7 == 0)
            {
                i.R7 = 255;
            }
            else
            {
                i.R7--;
            }
        }
    }
}
