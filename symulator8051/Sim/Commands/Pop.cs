namespace symulator8051.Sim.Commands
{
    class xD0 : ICommand //CPL bit address
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
        public xD0(I8051 i, byte arg)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.SP] = i.SP;
            i.SP--;
        }
    }
}