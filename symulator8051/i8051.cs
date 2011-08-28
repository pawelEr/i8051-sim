using System;

using System.ComponentModel;

namespace symulator8051
{
    class I8051 : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        #region memory/registers
        private byte[] SFR = new byte[0x100]; // rejestry funkcji specjalnych 
        private byte[] EXT_RAM = new byte[0x10000]; //zewnetrzna pamiec 64kB
        private byte[] EXT_PMEM = new byte[0x10000]; //zewnetrzna pamiec na program 64kb 

        public byte ACC //akumulator
        {
            get { return SFR[0xe0]; }
            set
            {
                SFR[0xe0] = value;
                OnPropertyChanged("ACC");
            }

        }
        private byte[] convert16to2x8(ushort numb) //rozdziela liczbe 16bit na 2 8bit
        {

            byte[] bytes = new byte[2];
            bytes = BitConverter.GetBytes(numb);
            return bytes;
        }
        public ushort DPTR //wskaznik danych 16-bit
        {
            get { return (ushort)SFR[0x82]; }
            set
            {
                byte[] temp = new byte[2];
                temp = convert16to2x8(value);
                DPH = temp[0];
                DPL = temp[1];
            }
        }
        public byte DPH //wyższe bity DPTR
        {
            get { return SFR[0x83]; }
            set
            {
                SFR[0x83] = value;
                OnPropertyChanged("DPH");
            }
        }

        public byte DPL //niższe bity DPTR
        {
            get { return SFR[0x82]; }
            set
            {
                SFR[0x82] = value;
                OnPropertyChanged("DPL");
            }
        }
        public byte B //rejestr B
        {
            get { return SFR[0xf0]; }
            set 
            { 
                SFR[0xf0] = value;
                OnPropertyChanged("B");
            }
        }
        public byte SP //wskaźnik stosu (stack pointer)
        {
            get { return SFR[0x81]; }
            set
            {
                SFR[0x81] = value;
                OnPropertyChanged("SP");
            }
        }
        public byte PSW //stany rejestru programu
        {
            get { return SFR[0xd0]; }
            set
            { 
                SFR[0xd0] = value;
                OnPropertyChanged("PSW");
            }
        }
        public byte P0 //pierwszy port
        {
            get { return SFR[0x80]; }
            set 
            { 
                SFR[0x80] = value;
                OnPropertyChanged("P0");
            }
        }

        public byte P1 //drugi port
        {
            get { return SFR[0x90]; }
            set 
            { 
                SFR[0x90] = value;
                OnPropertyChanged("P1");
            }
        }
        public byte P2 //trzeci port
        {
            get { return SFR[0xa0]; }
            set 
            {
                SFR[0xa0] = value;
                OnPropertyChanged("P2");
            }
        }
        public byte P3 //czwarty port
        {
            get { return SFR[0xb0]; }
            set 
            { 
                SFR[0xb0] = value;
                OnPropertyChanged("P3");
            }
        }
        public byte SBUF //serial transmission buffer
        {
            get { return SFR[0x99]; }
            set { SFR[0x99] = value; }
        }
        public byte IE //interrupt enable
        {
            get { return SFR[0xa8]; }
            set
            {
                SFR[0xa8] = value;
                OnPropertyChanged("IE");
            }
        }
        public byte IP //interrupt priority
        {
            get { return SFR[0xc0]; }
            set
            {
                SFR[0xc0] = value;
                OnPropertyChanged("IP");
            }
        }
        public byte SCON //serial control
        {
            get { return SFR[0x98]; }
            set { SFR[0x98] = value; }
        }
        public byte TH1 //timer 1 high
        {
            get { return SFR[0x8d]; }
            set { SFR[0x8d] = value; }
        }
        public byte TL1 //timer 1 low
        {
            get { return SFR[0x8b]; }
            set { SFR[0x8b] = value; }
        }
        public byte TH0 //timer 0 high
        {
            get { return SFR[0x8c]; }
            set { SFR[0x8c] = value; }
        }
        public byte TL0 //timer 0 low
        {
            get { return SFR[0x8a]; }
            set { SFR[0x8c] = value; }
        }
        public byte TMOD //timer mode
        {
            get { return SFR[0x89]; }
            set { SFR[0x89] = value; }
        }
        public byte TCON //timer control
        {
            get { return SFR[0x88]; }
            set { SFR[0x88] = value; }
        }
        public byte PCON //power control
        {
            get { return SFR[0x87]; }
            set { SFR[0x87] = value; }
        }
        public byte R0 //register R0
        {
            get { return SFR[0x00]; }
            set 
            { 
                SFR[0x00] = value;
                OnPropertyChanged("RO");
            }
        }
        public byte R1 //register R1
        {
            get { return SFR[0x01]; }
            set 
            { 
                SFR[0x01] = value;
                OnPropertyChanged("R1");
            }
        }
        public byte R2 //register R2
        {
            get { return SFR[0x02]; }
            set 
            { 
                SFR[0x02] = value;
                OnPropertyChanged("R2");
            }
        }
        public byte R3 //register R3
        {
            get { return SFR[0x03]; }
            set 
            { 
                SFR[0x03] = value;
                OnPropertyChanged("R3");
            }
        }
        public byte R4 //register R4
        {
            get { return SFR[0x04]; }
            set 
            {
                SFR[0x04] = value;
                OnPropertyChanged("R4");
            }
        }
        public byte R5 //register R5
        {
            get { return SFR[0x05]; }
            set 
            { 
                SFR[0x05] = value;
                OnPropertyChanged("R5");
            }
        }
        public byte R6 //register R6
        {
            get { return SFR[0x06]; }
            set 
            { 
                SFR[0x06] = value;
                OnPropertyChanged("R6");
            }
        }
        public byte R7 //register R7
        {
            get { return SFR[0x07]; }
            set 
            { 
                SFR[0x07] = value;
                OnPropertyChanged("R7");
            }
        }
        private ushort pc;
        public ushort PC
        {
            get { return pc; }
            set 
            { 
                pc = value;
                OnPropertyChanged("PC");
            }
        }

        #endregion
        public I8051()
        {
            for (int i = 0; i < SFR.Length; i++)
                SFR[i] = 0;
            this.P0 = 0xff;
            this.P1 = 0xff;
            this.P2 = 0xff;
            this.P3 = 0xff;
            this.PC = 0x0000;
            this.SP = 0x07;
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void process()
        {
            string code = null;
            SourceCode s = new SourceCode();
            CommandEngine c = new CommandEngine(this);

            foreach (Line l in s.processedLines)
            {

                code = l.code.Trim().ToLower();

                switch (code)
                {
                    #region dupny switch
                    case "acall":

                        break;
                    case "add":

                        break;
                    case "addc":

                        break;
                    case "ajmp":

                        break;
                    case "anl":

                        break;
                    case "cjne":

                        break;
                    case "clr":

                        break;
                    case "cpl":

                        break;
                    case "da":

                        break;
                    case "dec":

                        break;
                    case "div":

                        break;
                    case "djnz":

                        break;
                    case "inc":

                        break;
                    case "jb":

                        break;
                    case "jbc":

                        break;
                    case "jc":

                        break;
                    case "jmp":

                        break;
                    case "jnb":

                        break;
                    case "jnc":

                        break;
                    case "jnz":

                        break;
                    case "jz":

                        break;
                    case "lcall":

                        break;
                    case "ljmp":

                        break;
                    case "mov":
                        c.AddCommand(new Mov());
                        break;
                    case "movc":

                        break;
                    case "movx":

                        break;
                    case "mul":

                        break;
                    case "nop":
                        c.AddCommand(new Nop());
                        break;
                    case "orl":

                        break;
                    case "pop":

                        break;
                    case "push":

                        break;
                    case "ret":

                        break;
                    case "reti":

                        break;
                    case "rl":

                        break;
                    case "rlc":

                        break;
                    case "rr":

                        break;
                    case "rrc":

                        break;
                    case "setb":

                        break;
                    case "sjmp":

                        break;
                    case "subb":

                        break;
                    case "swap":

                        break;
                    case "xch":

                        break;
                    case "xchd":

                        break;
                    case "xlr":

                        break;
                    #endregion
                }

            }
            c.Run();
        }
    }
}
