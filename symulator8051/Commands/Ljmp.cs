using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class x02 : ICommand // LJMP code addr
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
        public x02(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg2;
        }
        private UInt16 addH;
        private UInt16 addL;
        public void execute()
        {
            addH = i.SFR[arg];
            addL = i.SFR[arg];
            i.PC = (UInt16)(addH << 8 | addL);
        }
    }
}