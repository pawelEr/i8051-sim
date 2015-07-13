namespace symulator8051.Sim.Commands
{
    class x73 : ICommand //JMP @A+DPTR
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
        
        public x73(I8051 i)
        {
            this.i = i;           
        }
        public void execute()
        {
            i.PC =(ushort)( i.ACC + i.DPTR);
        }
    }
}