using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051.Commands
{
	class x34 : ICommand //ADDC A, #data
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
		public x34(I8051 i, byte arg)
		{
			this.i = i;
			this.arg = arg;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.SFR[arg] + Convert.ToUInt16( i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.SFR[arg] & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.SFR[arg] & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x35 : ICommand //ADDC A, iram addr
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
		public x35(I8051 i, byte arg)
		{
			this.i = i;
			this.arg = arg;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + arg + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (arg & 0x0f) + Convert.ToUInt16( i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (arg & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x36 : ICommand //ADDC A, @R0
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

		public x36(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.EXT_RAM[i.R0] + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.EXT_RAM[i.R0] & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.EXT_RAM[i.R0] & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}

	class x37 : ICommand //ADDC A, @R1
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

		public x37(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.EXT_RAM[i.R1] + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.EXT_RAM[i.R1] & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.EXT_RAM[i.R1] & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x38 : ICommand //ADDC A, R0
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

		public x38(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R0 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R0 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R0 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x39 : ICommand //ADDC A, R1
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

		public x39(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R1 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R1 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R1 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3A : ICommand //ADDC A, R2
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

		public x3A(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R2 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R2 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R2 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3B : ICommand //ADDC A, R3
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

		public x3B(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R3 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R3 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R3 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3C : ICommand //ADDC A, R4
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

		public x3C(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R4 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R4 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R4 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3D : ICommand //ADDC A, R5
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

		public x3D(I8051 i)
		{
			this.i = i;
		}
		public UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R5 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R5 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R5 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3E : ICommand //ADDC A, R6
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

		public x3E(I8051 i)
		{
			this.i = i;
		}
		public UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R6 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R6 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R6 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
	class x3F : ICommand //ADDC A, R7
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

		public x3F(I8051 i)
		{
			this.i = i;
		}
		private UInt16 temp;
		public void execute()
		{
			temp = (UInt16)(i.ACC + i.R7 + Convert.ToUInt16(i.OV));
			i.PSW = i.PSW.clrBit(bits.bit8);
			i.PSW = i.PSW.clrBit(bits.bit3);
			i.PSW = i.PSW.clrBit(bits.bit7);
			if ((i.ACC & 0x0f) + (i.R7 & 0x0f) + Convert.ToUInt16(i.OV) > 0x0f)
				i.PSW = i.PSW.setBit(bits.bit7);
			if ((i.ACC & 0x7f) + (i.R7 & 0x7f) + Convert.ToUInt16(i.OV) > 0x7f)
				i.PSW = i.PSW.setBit(bits.bit3);
			if (temp > 0xff)
			{
				i.PSW = i.PSW.setBit(bits.bit8);
				if (!i.PSW.chkBit(bits.bit3))
					i.PSW = i.PSW.setBit(bits.bit3);
				else
					i.PSW = i.PSW.clrBit(bits.bit3);
			}
			i.ACC = (byte)temp;
		}
	}
}