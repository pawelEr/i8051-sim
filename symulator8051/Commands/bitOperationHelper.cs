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
        public static byte clrBit(this byte b, byte setBit)
        {
            if(b.chkBit(setBit))
            {}
            else
            {
                b^=setBit;  //b= b XOR setBit
            }
            return b;
        }
        public static byte setBit(this byte b, byte clrBit)
        {
            if (b.chkBit(clrBit))
            {
                b ^= clrBit; //b= b XOR clrBits
            }
            return b;
        }
    }
}
