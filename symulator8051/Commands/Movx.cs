using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class xE0 : ICommand //MOVX A,@DPTR
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xE0(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC =i.EXT_RAM2[i.DPTR];
        }
    }
    class xE2 : ICommand //MOVX A,@R0
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xE2(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_RAM2[i.R0];
        }
    }
    class xE3 : ICommand //MOVX A,@R1
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xE3(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_RAM2[i.R1];
        }
    }
    class xF0 : ICommand //MOVX @DPTR,A
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xF0(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM2[i.DPTR] = i.ACC;
        }
    }
    class xF2 : ICommand //MOVX @R0,A
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xF2(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM2[i.R0] = i.ACC;
        }
    }
    class xF3 : ICommand //MOVX @R1,A
    {
        I8051 i;
        private byte cycles = 1;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xF3(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM2[i.R1] = i.ACC;
        }
    }
}