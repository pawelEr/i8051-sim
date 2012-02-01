using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x22 : ICommand //RET
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
        public x22(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            byte addrH = i.EXT_RAM[i.SP];
            i.SP =(byte)(i.SP-1);
            byte addrL=i.EXT_RAM[i.SP];
            i.SP=(byte)(i.SP-1);
            i.PC=(UInt16)(addrH<<8|addrL);
        }
    }
    class x32 : ICommand //RETI
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
        public x32(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            byte addrH = i.EXT_RAM[i.SP];
            i.SP = (byte)(i.SP - 1);
            byte addrL = i.EXT_RAM[i.SP];
            i.SP = (byte)(i.SP - 1);
            i.PC = (UInt16)(addrH << 8 | addrL);
        }
    }
}