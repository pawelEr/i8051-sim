using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class x94 : ICommand //SUBB A, #data
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
        public x94(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.SFR[arg]);
        }
    }
    class x95 : ICommand //SUBB A, iram addr
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
        public x95(I8051 i, byte arg)
        {
            this.i = i;
            this.arg = arg;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - arg);
        }
    }
    class x96 : ICommand //SUBB A, @R0
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
       
        public x96(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.EXT_RAM[i.R0]);
        }
    }

    class x97 : ICommand //SUBB A, @R1
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
        
        public x97(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.EXT_RAM[i.R1]);
        }
    }
    class x98 : ICommand //SUBB A, R0
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
        
        public x98(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R0);
        }
    }
    class x99 : ICommand //SUBB A, R1
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
        
        public x99(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R1);
        }
    }
    class x9A : ICommand //SUBB A, R2
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
        
        public x9A(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R2);
        }
    }
    class x9B : ICommand //SUBB A, R3
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
        
        public x9B(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R3);
        }
    }
    class x9C : ICommand //SUBB A, R4
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
    
        public x9C(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R4);
        }
    }
    class x9D : ICommand //SUBB A, R5
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
        
        public x9D(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R5);
        }
    }
    class x9E : ICommand //SUBB A, R6
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
       
        public x9E(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R6);
        }
    }
    class x9F : ICommand //SUBB A, R7
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
        
        public x9F(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = Convert.ToByte(i.ACC - i.R7);
        }
    }
}