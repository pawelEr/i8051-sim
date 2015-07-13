using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
	class xC2 : ICommand //CLR bit addr
	{
		I8051 i;
		private byte cycles = 1;
		public byte Cycles
		{
			get { return cycles; }
		}
		private byte arg;
		public xC2(I8051 i, byte arg)
		{
			this.i = i;
			this.arg = arg;
		}
		public void execute()
		{
			byte memDest = bitAddressingOperationHelper.getByteAddrFromBitAddr(arg);

			int bitDest = arg % 8;

			i.EXT_RAM[memDest]=i.EXT_RAM[memDest].clrBit(bitDest);
		}

		private ushort bytes = 2;
		public ushort Bytes
		{
			get { return bytes; }
		}
	}
	class xC3 : ICommand //CLR C
	{
		I8051 i;
		private byte cycles = 1;
		public byte Cycles
		{
			get { return cycles; }
		}
		public xC3(I8051 i)
		{
			this.i = i;
		}
		public void execute()
		{
			i.PSW = i.PSW.clrBit(bits.bit8);
		}

		private ushort bytes = 1;
		public ushort Bytes
		{
			get { return bytes; }
		}
	}
	class xE4 : ICommand //CLR A
	{
		I8051 i;
		private byte cycles = 1;
		public byte Cycles
		{
			get { return cycles; }
		}
		public xE4(I8051 i)
		{
			this.i = i;
		}
		public void execute()
		{
			i.ACC = 0x00;
		}

		private ushort bytes = 1;
		public ushort Bytes
		{
			get { return bytes; }
		}
	}
}
