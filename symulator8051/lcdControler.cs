using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteExtensionMethods;

namespace symulator8051
{
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
        private void setLCD()
        {
            currentLcd=0;
            if(i.P3.chkBit(Commands.bits.bit4))
                currentLcd+=1;
            if(i.P3.chkBit(Commands.bits.bit5))
                currentLcd+=2;
        }
        private void checkActive()
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
        public void refresh()
        {
            setLCD();
            checkActive();
            m.lcdControl1.CustomPattern = 0x00;
            m.lcdControl2.CustomPattern = 0x00;
            m.lcdControl3.CustomPattern = 0x00;
            m.lcdControl4.CustomPattern = 0x00;
            if(active)
                switch (currentLcd)
                {
                    case 0:
                        m.lcdControl1.CustomPattern = ~i.P1;
                        break;
                    case 1:
                        m.lcdControl2.CustomPattern = ~i.P1;
                        break;
                    case 2:
                        m.lcdControl3.CustomPattern = ~i.P1;
                        break;
                    case 3:
                        m.lcdControl4.CustomPattern = ~i.P1;
                        break;
                }
        }
    }
}