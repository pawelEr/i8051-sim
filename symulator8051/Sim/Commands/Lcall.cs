using System;

namespace symulator8051.Sim.Commands
{
	class x12 : ICommand //LCALL adress(16bit)
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
		public x12(I8051 i,byte arg, byte arg2)
		{
			this.i = i;
			this.arg = arg;
			this.arg2 = arg2;
		}
		public void execute()
		{
			i.SP = (byte)(i.SP + 1);
			i.EXT_RAM[i.SP] = (byte)(i.PC&0xFF);
			i.SP = (byte)(i.SP + 1);
			i.EXT_RAM[i.SP] = (byte)(i.PC>>8);
			i.SP = (byte)(arg | arg2);
			i.PC = (UInt16)(arg << 8 | arg2);
		}
	}
}
