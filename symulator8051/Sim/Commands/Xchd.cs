namespace symulator8051.Sim.Commands
{
    class xD6 : ICommand //XCHD A,@R0
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
        public xD6(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            byte temp = i.ACC;
            i.ACC = (byte)((i.ACC & 0xf0) | i.EXT_RAM[i.R0] & 0x0f);
            i.EXT_RAM[i.R0] = (byte)((i.EXT_RAM[i.R0] & 0xf0) | (temp & 0x0f));
        }
    }
    class xD7 : ICommand //XCHD A,@R1
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
        public xD7(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            byte temp = i.ACC;
            i.ACC = (byte)((i.ACC & 0xf0) | i.EXT_RAM[i.R1] & 0x0f);
            i.EXT_RAM[i.R1] = (byte)((i.EXT_RAM[i.R1] & 0xf0) | (temp & 0x0f));
        }
    }
}