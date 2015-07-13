using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Sim;

namespace symulator8051.Commands
{
	class x23 : ICommand //RL
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
		public x23(I8051 i)
		{
			this.i = i;
		}
		public void execute()
		{
			byte b7 = Convert.ToByte(ByteHelper.chkBit(i.ACC, 7));
			i.ACC = (byte)((i.ACC << 1) | b7);
		}
	}
	class x33 : ICommand //RLC
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
		public x33(I8051 i)
		{
			this.i = i;
		}
		public void execute()
		{
			byte b0 = Convert.ToByte(ByteHelper.chkBit(i.ACC, 7));
			i.ACC = (byte)((i.ACC << 1) | Convert.ToInt16((i.CY)));
			if (b0 == 1)
			{
				i.PSW = i.PSW.setBit(bits.bit7);
			}
			else
			{
				i.PSW = i.PSW.clrBit(bits.bit7);
			}
		}
	}
}