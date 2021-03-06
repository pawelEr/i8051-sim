﻿namespace symulator8051.Sim.Commands
{
    // PC ma byc podniesiony o 1 przed zamiast po operacji dla x83
    class x93 : ICommand //MOVC A, A+@DPTR
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
        public x93(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_PMEM[i.ACC + i.DPTR].Data;
        }
    }
    class x83 : ICommand //MOVC A, @A+PC
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
        public x83(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_PMEM[i.ACC + i.PC].Data;
        }
    }

}
