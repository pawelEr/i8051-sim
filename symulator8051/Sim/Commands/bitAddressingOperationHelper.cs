namespace symulator8051.Sim.Commands
{
	class bitAddressingOperationHelper
	{
		public static byte getByteAddrFromBitAddr(byte arg)
		{
			byte memDest = 0xFF;
			if (arg < 0x80) //0x20-0x2F
			{
				memDest = (byte)(0x20 + (arg / 8));
			}
			else if (arg < 0x88) //P0 0x80
			{
				memDest = 0x80;
			}
			else if (arg < 0x90) //TCON 0x88
			{
				memDest = 0x88;
			}
			else if (arg < 0x98) //P1 0x90
			{
				memDest = 0x90;
			}
			else if (arg < 0xA0) //SCON 0x98
			{
				memDest = 0x98;
			}
			else if (arg < 0xA8) //P2 0xA0
			{
				memDest = 0xA0;
			}
			else if (arg < 0xB0) //IE 0xA8
			{
				memDest = 0xA8;
			}
			else if (arg < 0xB8) //P3 0xB0
			{
				memDest = 0xB0;
			}
			else if (arg < 0xD0) //IP 0xB8
			{
				memDest = 0xB8;
			}
			else if (arg < 0xE0) //PSW 0xD0
			{
				memDest = 0xD0;
			}
			else if (arg < 0xF0)//ACC 0xE0
			{
				memDest = 0xE0;
			}
			else if (arg < 0xf8)//B 0xF0
			{
				memDest = 0xF0;
			}
			return memDest;
		}
	}
}
