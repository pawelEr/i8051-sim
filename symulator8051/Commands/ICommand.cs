using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{
    interface ICommand
    {
        byte Cycles { get; }
        ushort Bytes { get; }
        void execute();
    }
}
