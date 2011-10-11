using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051.Commands
{
    class xA4 : ICommand //MUL AB
    {
        I8051 i;
        private byte cycles = 4;
        public byte Cycles
        {
            get { return cycles; }
        }
        private ushort bytes = 1;
        public ushort Bytes
        {
            get { return bytes; }
        }
        public xA4(I8051 i)
        {
            this.i = i;
        }
        private byte temp;
        public void execute()
        {
            if (i.ACC * i.B > 255)
            {

            }
            if (i.ACC * i.B < 255)
            {

            }
            temp = Convert.ToByte((i.ACC * i.B) % 256 );
            i.ACC = Convert.ToByte((i.ACC * i.B) / 256);
            i.B = temp;
        }
    }
}