using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
	public static class bits
	{
		//bity gotowe do wstawiania:)
		public static byte bit1 = 1;
		public static byte bit2 = 2;
		public static byte bit3 = 4;
		public static byte bit4 = 8;
		public static byte bit5 = 16;
		public static byte bit6 = 32;
		public static byte bit7 = 64;
		public static byte bit8 = 128;
	}
}


namespace ByteExtensionMethods
{
	public static class ByteHelper
	{
		private static byte num2BitMask(int bitNum)
		{
			byte setBit = 0;
			switch (bitNum)
			{
				case 0:
					setBit = symulator8051.Commands.bits.bit1;
					break;
				case 1:
					setBit = symulator8051.Commands.bits.bit2;
					break;
				case 2:
					setBit = symulator8051.Commands.bits.bit3;
					break;
				case 3:
					setBit = symulator8051.Commands.bits.bit4;
					break;
				case 4:
					setBit = symulator8051.Commands.bits.bit5;
					break;
				case 5:
					setBit = symulator8051.Commands.bits.bit6;
					break;
				case 6:
					setBit = symulator8051.Commands.bits.bit7;
					break;
				case 7:
					setBit = symulator8051.Commands.bits.bit8;
					break;
			}
			return setBit;
		}
		public static bool chkBit(this byte b, byte checkedByte)
		{
			if ((b & checkedByte) == checkedByte)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool chkBit(this byte b, int checkedByteNum)
		{
			byte checkedByte = num2BitMask(checkedByteNum);
			if ((b & checkedByte) == checkedByte)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static byte setBit(this byte b, byte setBit)
		{
			if (b.chkBit(setBit))
			{ }
			else
			{
				b ^= setBit;  //b= b XOR setBit
			}
			return b;
		}
		public static byte setBit(this byte b, int bitNum)
		{
			byte setBit = num2BitMask(bitNum);

			if (b.chkBit(setBit))
			{ }
			else
			{
				b ^= setBit;  //b= b XOR setBit
			}
			return b;
		}
		public static byte clrBit(this byte b, byte clrBit)
		{
			if (b.chkBit(clrBit))
			{
				b ^= clrBit; //b= b XOR clrBits
			}
			return b;
		}
		public static byte clrBit(this byte b, int numClrBit)
		{
			byte clrBit = num2BitMask(numClrBit);
			if (b.chkBit(clrBit))
			{
				b ^= clrBit; //b= b XOR clrBits
			}
			return b;
		}
	}
}
