using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x20 : ICommand //JB bit,adres
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
        public x20(I8051 i, byte arg, byte arg2)
        {
            this.i = i;
            this.arg = arg;
            this.arg2 = arg2;
        }
        public void execute()
        {
            if (arg == 1)
            {
                i.PC = (ushort)(i.PC + arg2);
            }
        }
    }
    class x40 : ICommand //JC adres
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
        public x40(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;            
        }
        public void execute()
        {
            if ( Convert.ToInt16( i.CY) == 1)
            {
                i.PC = (ushort)(i.PC + arg);
            }
        }
    }
    class x50 : ICommand //JNC adres
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
        public x50(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (Convert.ToInt16(i.CY) == 0)
            {
                i.PC = (ushort)(i.PC + arg);
            }
        }
    }
    class x60 : ICommand //JZ adres
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
        public x60(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.ACC==0)
            {
                i.PC = (ushort)(i.PC + arg);
            }
        }
    }
    class x70 : ICommand //JNZ adres
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
        public x70(I8051 i,byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            if (i.ACC != 0)
            {
                i.PC = (ushort)(i.PC + arg);
            }
        }
    }

}