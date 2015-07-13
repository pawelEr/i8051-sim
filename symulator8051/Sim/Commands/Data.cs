namespace symulator8051.Sim.Commands
{
    class Data : ICommand
    {
        public byte Cycles
        {
            get { return 0; }
        }
        public ushort Bytes
        {
            get { return 1; }
        }
        public void execute()
        { }
    }
}
