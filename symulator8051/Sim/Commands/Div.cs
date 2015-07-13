namespace symulator8051.Sim.Commands
{
    class x84 : ICommand //DIV AB
    {
        I8051 i;
        private byte cycles = 4;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public x84(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            temp = (byte)(i.ACC % i.B);
            i.ACC = (byte)(i.ACC / i.B);
            i.B = temp;
        }
    }
}