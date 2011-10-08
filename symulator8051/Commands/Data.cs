using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
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
