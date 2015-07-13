using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
    class x11 : ICommand //ACALL  iram addr
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
        public x11(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp=(UInt16)(i.SFR[i.PC] | 0 );
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
         }
    }

    class x31 : ICommand //ACALL  iram addr
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
        public x31(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 1);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x51 : ICommand //ACALL  iram addr
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
        public x51(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 2);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x71 : ICommand //ACALL  iram addr
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
        public x71(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 3);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x91 : ICommand //ACALL  iram addr
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
        public x91(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 4);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class xB1 : ICommand //ACALL  iram addr
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
        public xB1(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 5);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class xD1 : ICommand //ACALL  iram addr
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
        public xD1(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 6);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class xF1 : ICommand //ACALL  iram addr
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
        public xF1(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 7);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)(i.PC & 0x00ff);
            i.SP = (byte)(i.SP + 1);
            i.EXT_RAM[i.SP] = (byte)((i.PC >> 8) & 0x00ff);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
}