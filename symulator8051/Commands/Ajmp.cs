using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
    class x01 : ICommand // AJMP code addr
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
        public x01(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 0);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x21 : ICommand // AJMP code addr
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
        public x21(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 1);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x41 : ICommand // AJMP code addr
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
        public x41(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 2);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x61 : ICommand // AJMP code addr
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
        public x61(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 3);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class x81 : ICommand // AJMP code addr
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
        public x81(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 4);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class xA1 : ICommand // AJMP code addr
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
        public xA1(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 5);
            i.PC = (UInt16)(i.PC | temp);
        }
    }
    class xC1 : ICommand // AJMP code addr
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
        public xC1(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        private UInt16 temp;
        public void execute()
        {
            temp = (UInt16)(i.SFR[i.PC] | 6);
            i.PC = (UInt16)(i.PC | temp);
        }
        class xE1 : ICommand // AJMP code addr
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
            public xE1(I8051 i, byte arg)
            {
                this.i = i;
                this.arg = arg;
            }
            private UInt16 temp;
            public void execute()
            {
                temp = (UInt16)(i.SFR[i.PC] | 7);
                i.PC = (UInt16)(i.PC | temp);
            }
        }
    }
}