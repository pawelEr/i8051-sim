using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class x24 : ICommand //ADD A, #data
    {
        I8051 i;
        private byte cycles = 1;
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
        public x24(I8051 i, byte arg )
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte( i.ACC + i.SFR[arg]);
        }
    }
    class x25 : ICommand //ADD A, iram addr
    {
        I8051 i;
        private byte cycles = 1;
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
        public x25(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + arg);
        }
    }
    class x26 : ICommand //ADD A, @R0
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
   
        public x26(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.EXT_RAM[i.R0]);
        }
    }

    class x27 : ICommand //ADD A, @R1
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
        
        public x27(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.EXT_RAM[i.R1]);
        }
    }
    class x28 : ICommand //ADD A, R0
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
     
        public x28(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R0);
        }
    }
    class x29 : ICommand //ADD A, R1
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
       
        public x29(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R1);
        }
    }
    class x2A : ICommand //ADD A, R2
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
        
        public x2A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R2);
        }
    }
    class x2B : ICommand //ADD A, R3
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
        
        public x2B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R3);
        }
    }
    class x2C : ICommand //ADD A, R4
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
     
        public x2C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R4);
        }
    }
    class x2D : ICommand //ADD A, R5
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
        
        public x2D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R5);
        }
    }
    class x2E : ICommand //ADD A, R6
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
       
        public x2E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R6);
        }
    }
    class x2F : ICommand //ADD A, R7
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
      
        public x2F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC + i.R7);
        }
    }
}