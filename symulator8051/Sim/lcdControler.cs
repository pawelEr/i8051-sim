using System.Windows.Forms.VisualStyles;
using DmitryBrant.CustomControls;
using symulator8051.Sim.Commands;

namespace symulator8051.Sim
{
	/*
	 * klasa odpowiedzialna za obsługe wyswietlacza 7 seg
	 */
	class lcdControler
	{
		private byte currentLcd;
		private bool active;
		private SevenSegment sevenSegment1;
		private SevenSegment sevenSegment2;
		private SevenSegment sevenSegment3;
		private SevenSegment sevenSegment4;
		private I8051 i;

		public I8051 I8051
		{
			set { i = value; }
		}

		public lcdControler(SevenSegment sevenSegment1, SevenSegment sevenSegment2, SevenSegment sevenSegment3,
			SevenSegment sevenSegment4)
		{
			this.sevenSegment1 = sevenSegment1;
			this.sevenSegment2 = sevenSegment2;
			this.sevenSegment3 = sevenSegment3;
			this.sevenSegment4 = sevenSegment4;
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
			active = i.P0.chkBit(Commands.bits.bit8);
		}

		public void refresh() //odświerza wartość wyświetlacza
		{
			setLCD();
			checkActive();
			sevenSegment1 .CustomPattern = 0x00;
			sevenSegment2.CustomPattern = 0x00;
			sevenSegment3.CustomPattern = 0x00;
			sevenSegment4.CustomPattern = 0x00;
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
						sevenSegment1.CustomPattern = translatedPattern;
						break;
					case 1:
						sevenSegment2.CustomPattern = translatedPattern;
						break;
					case 2:
						sevenSegment3.CustomPattern = translatedPattern;
						break;
					case 3:
						sevenSegment4.CustomPattern = translatedPattern;
						break;
				}
		}
	}
}