using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;
using symulator8051.Commands;

namespace symulator8051
{
	/*
	 * klasa odpowiedzialna za obsługe wyswietlacza 7 seg
	 */
	class lcdControler
	{
		private byte currentLcd;
		private bool active;
		private Main m;
		private I8051 i;
		public lcdControler(Main m, I8051 i)
		{
			this.m=m;
			this.i=i;
		}
		private void setLCD() //ustawia wartośc  wyświetlacza na podstawie portu P3
		{
			currentLcd=0;
			if(i.P3.chkBit(Commands.bits.bit4))
				currentLcd+=1;
			if(i.P3.chkBit(Commands.bits.bit5))
				currentLcd+=2;
		}
		private void checkActive() //sprawdza czy jest ustawiony bit odpowiedzialny za aktywacje wyświetlacza
		{
			if (i.P0.chkBit(Commands.bits.bit8))
			{
				active = true;
			}
			else
			{
				active = false;
			}
		}
		public void refresh() //odświerza wartość wyświetlacza
		{
			setLCD();
			checkActive();
			m.lcdControl1.CustomPattern = 0x00;
			m.lcdControl2.CustomPattern = 0x00;
			m.lcdControl3.CustomPattern = 0x00;
			m.lcdControl4.CustomPattern = 0x00;
			byte translatedPattern = 0x00;

			if (!i.P1.chkBit(bits.bit1))
				translatedPattern = translatedPattern.setBit(bits.bit1);
			if (!i.P1.chkBit(bits.bit2))
				translatedPattern = translatedPattern.setBit(bits.bit3);
			if (!i.P1.chkBit(bits.bit3))
				translatedPattern = translatedPattern.setBit(bits.bit6);
			if (!i.P1.chkBit(bits.bit4))
				translatedPattern = translatedPattern.setBit(bits.bit7);
			if (!i.P1.chkBit(bits.bit5))
				translatedPattern = translatedPattern.setBit(bits.bit5);
			if (!i.P1.chkBit(bits.bit6))
				translatedPattern = translatedPattern.setBit(bits.bit2);
			if (!i.P1.chkBit(bits.bit7))
				translatedPattern = translatedPattern.setBit(bits.bit4);

			if(active)
				switch (currentLcd)
				{
					case 0:
						m.lcdControl1.CustomPattern = translatedPattern;
						break;
					case 1:
						m.lcdControl2.CustomPattern = translatedPattern;
						break;
					case 2:
						m.lcdControl3.CustomPattern = translatedPattern;
						break;
					case 3:
						m.lcdControl4.CustomPattern = translatedPattern;
						break;
				}
		}
	}
}