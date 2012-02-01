﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x10 : ICommand //JBC bit,adres
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
        public x10(I8051 i,byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg2;
        }
        public void execute()
        {
            if ( arg == 1)
            {
                ByteHelper.clrBit(arg, 0);
                i.PC = (ushort)(i.PC + arg2);
            }
        }
    }
}