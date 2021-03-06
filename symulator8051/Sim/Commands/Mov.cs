﻿/* 
 * 
 *BRAKUJE xA2 MOV C, bit addr i x92 MOV bit addr, C 
 * 
 */


namespace symulator8051.Sim.Commands
{
    class x76 : ICommand //MOV @R0, #data
    {
        byte arg;
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
        public x76(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R0] = arg;
        }
    }
    class x77 : ICommand //MOV @R1, #data
    {
        byte arg;
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
        public x77(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R1] = arg;
        }
    }
    class xF6 : ICommand //MOV @R0, A
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
        public xF6(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R0] = i.ACC;
        }
    }
    class xF7 : ICommand //MOV @R1, A
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
        public xF7(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R1] = i.ACC;
        }
    }
    class xA6 : ICommand //MOV @R0, iram addr
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
        public xA6(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R1] = i.SFR[arg];
        }
    }
    class xA7 : ICommand //MOV @R1, iram addr
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
        public xA7(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.EXT_RAM[i.R1] = i.SFR[arg];
        }
    }
    class x74 : ICommand //MOV A,#data
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
        public x74(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.ACC = arg;
        }
    }
    class xE6 : ICommand //MOV A, @R0
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
        public xE6(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_RAM[i.R0];
        }
    }
    class xE7 : ICommand //MOV A, @R1
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
        public xE7(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.EXT_RAM[i.R1];
        }
    }
    class xE8 : ICommand //MOV A, R0
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
        public xE8(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R0;
        }
    }
    class xE9 : ICommand //MOV A, R1
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
        public xE9(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R1;
        }
    }
    class xEA : ICommand //MOV A, R2
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
        public xEA(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R2;
        }
    }
    class xEB : ICommand //MOV A, R3
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
        public xEB(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R3;
        }
    }
    class xEC : ICommand //MOV A, R4
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
        public xEC(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R4;
        }
    }
    class xED : ICommand //MOV A, R5
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
        public xED(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R5;
        }
    }
    class xEE : ICommand //MOV A, R6
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
        public xEE(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R6;
        }
    }
    class xEF : ICommand //MOV A, R7
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
        public xEF(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.R7;
        }
    }
    class xE5 : ICommand //MOV A, iram addr
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
        public xE5(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.ACC = i.SFR[arg];
        }
    }
    class x90 : ICommand //MOV DPTR, #data16
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
        private ushort arg;
        public x90(ushort arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.DPTR = arg;
        }
    }
    class x78 : ICommand //MOV R0,#data
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
        public x78(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R0 = arg;
        }
    }
    class x79 : ICommand //MOV R1, #data
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
        public x79(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R1 = arg;
        }
    }
    class x7A : ICommand //MOV R2, #data
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
        public x7A(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R2 = arg;
        }
    }
    class x7B : ICommand //MOV R3, #data
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
        public x7B(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R3 = arg;
        }
    }
    class x7C : ICommand //MOV R4, #data
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
        public x7C(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R4 = arg;
        }
    }
    class x7D : ICommand //MOV R5, #data
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
        public x7D(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R5 = arg;
        }
    }
    class x7E : ICommand //MOV R6, #data
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
        public x7E(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R6 = arg;
        }
    }
    class x7F : ICommand //MOV R7, #data
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
        public x7F(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R7 = arg;
        }
    }
    class xF8 : ICommand //MOV R0, A
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
        public xF8(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R0 = i.ACC;
        }
    }
    class xF9 : ICommand //MOV R1, A
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
        public xF9(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R1 = i.ACC;
        }
    }
    class xFA : ICommand //MOV R2, A
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
        public xFA(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R2 = i.ACC;
        }
    }
    class xFB : ICommand //MOV R3, A
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
        public xFB(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R3 = i.ACC;
        }
    }
    class xFC : ICommand //MOV R4, A
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
        public xFC(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R4 = i.ACC;
        }
    }
    class xFD : ICommand //MOV R5, A
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
        public xFD(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R5 = i.ACC;
        }
    }
    class xFE : ICommand //MOV R6, A
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
        public xFE(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R6 = i.ACC;
        }
    }
    class xFF : ICommand //MOV R7, A
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
        public xFF(I8051 i)
        {
            this.i = i;
        }
        public void execute()
        {
            i.R7 = i.ACC;
        }
    }
    class xA8 : ICommand //MOV R0, iram addr
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
        public xA8(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R0 = i.SFR[arg];
        }
    }
    class xA9 : ICommand //MOV R1, iram addr
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
        public xA9(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R1 = i.SFR[arg];
        }
    }
    class xAA : ICommand //MOV R2, iram addr
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
        public xAA(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R2 = i.SFR[arg];
        }
    }
    class xAB : ICommand //MOV R3, iram addr
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
        public xAB(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R3 = i.SFR[arg];
        }
    }
    class xAC: ICommand //MOV R4, iram addr
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
        public xAC(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R4 = i.SFR[arg];
        }
    }
    class xAD : ICommand //MOV R5, iram addr
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
        public xAD(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R5 = i.SFR[arg];
        }
    }
    class xAE : ICommand //MOV R6, iram addr
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
        public xAE(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R6 = i.SFR[arg];
        }
    }
    class xAF : ICommand //MOV R7, iram addr
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
        public xAF(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.R7 = i.SFR[arg];
        }
    }
    class x75 : ICommand //MOV iram addr, #data
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
        public x75(byte arg, byte arg2, I8051 i)
        {
            this.arg = arg;
            this.arg2 = arg2;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg]=arg2;
        }
    }
    class x86 : ICommand //MOV iram addr, @R0
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
        public x86(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.EXT_RAM[i.R0];
        }
    }
    class x87 : ICommand //MOV iram addr, @R1
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
        public x87(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.EXT_RAM[i.R1];
        }
    }
    class x88 : ICommand //MOV iram addr, R0
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
        public x88(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R0;
        }
    }
    class x89 : ICommand //MOV iram addr, R1
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
        public x89(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R1;
        }
    }
    class x8A : ICommand //MOV iram addr, R2
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
        public x8A(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R2;
        }
    }
    class x8B : ICommand //MOV iram addr, R3
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
        public x8B(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R3;
        }
    }
    class x8C : ICommand //MOV iram addr, R4
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
        public x8C(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R4;
        }
    }
    class x8D : ICommand //MOV iram addr, R5
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
        public x8D(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R5;
        }
    }
    class x8E : ICommand //MOV iram addr, R6
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
        public x8E(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.R6;
        }
    }
    class x8F : ICommand //MOV iram addr, R7
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
        public x8F(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
       
            i.SFR[arg] = i.R7;
        }
    }
    class xF5 : ICommand //MOV iram addr, A
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
        public xF5(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg] = i.ACC;
        }
    }
    class x85 : ICommand //MOV iram addr, R0
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
        public x85(byte arg, byte arg2, I8051 i)
        {
            this.arg = arg;
            this.arg2 = arg2;
            this.i = i;
        }
        public void execute()
        {
            i.SFR[arg2] = i.SFR[arg];
        }
    }
    class x92 : ICommand //MOV bit addres, C
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
        public x92(byte arg,  I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            if (i.CY)
                i.EXT_RAM[arg / 8 + 0x20] = i.EXT_RAM[arg / 8 + 0x20].clrBit(arg % 8);
            else
                i.EXT_RAM[arg / 8 + 0x20] = i.EXT_RAM[arg / 8 + 0x20].setBit(arg % 8);
        }
    }
    class xA2 : ICommand //MOV C,bit addres
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
        public xA2(byte arg, I8051 i)
        {
            this.arg = arg;
            this.i = i;
        }
        public void execute()
        {
            i.CY = i.EXT_RAM[arg / 8 + 0x20].chkBit(arg % 8);
        }
    }
}
