﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{
    class Nop : ICommand
    {
        public byte cycles = 1;
        public byte Cycles 
        {
            get{return cycles;} 
        }
        public void execute()
        {
        }
    }
}
