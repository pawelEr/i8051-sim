﻿using System;

namespace symulator8051.Sim.Commands
{
	class x13 : ICommand //RR
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
		public x13(I8051 i)
		{
			this.i = i;
		}
		public void execute()
		{
			byte b0 = Convert.ToByte(ByteHelper.chkBit(i.ACC, 0));
			i.ACC = (byte)((i.ACC >> 1) | (Convert.ToInt16(i.CY) << 7));
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