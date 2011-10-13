using System;

using System.ComponentModel;
using symulator8051.Commands;
using ByteExtensionMethods;

namespace symulator8051
{
    class MemoryRecord
    {
        public byte Data;
        public ICommand Instruction;
    }
    class I8051 : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        #region memory/registers
        public byte[] SFR = new byte[0x100]; // rejestry funkcji specjalnych 
        public byte[] EXT_RAM = new byte[0x10000]; //zewnetrzna pamiec 64kB
        public MemoryRecord[] EXT_PMEM = new MemoryRecord[0x10000]; //zewnetrzna pamiec na program 64kb 

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
        public bool OV
        {
            get { return PSW.chkBit(bits.bit2); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit2);
                }
                else
                {
                    PSW.clrBit(bits.bit2);
                }
            }
        }
        public bool RS0
        {
            get { return PSW.chkBit(bits.bit3); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit3);
                }
                else
                {
                    PSW.clrBit(bits.bit3);
                }
            }
        }
        public bool RS1
        {
            get { return PSW.chkBit(bits.bit4); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit4);
                }
                else
                {
                    PSW.clrBit(bits.bit4);
                }
            }
        }
        public bool F0
        {
            get { return PSW.chkBit(bits.bit5); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit5);
                }
                else
                {
                    PSW.clrBit(bits.bit5);
                }
            }
        }
        public bool AC
        {
            get { return PSW.chkBit(bits.bit6); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit6);
                }
                else
                {
                    PSW.clrBit(bits.bit6);
                }
            }
        }
        public bool CY
        {
            get { return PSW.chkBit(bits.bit7); }
            set
            {
                if (value)
                {
                    PSW.setBit(bits.bit7);
                }
                else
                {
                    PSW.clrBit(bits.bit7);
                }
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
            for (int i = 0; i < this.EXT_PMEM.Length; i++)
                this.EXT_PMEM[i] = new MemoryRecord();
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
            SourceCode s = new SourceCode();
            CommandEngine c = new CommandEngine(this);
            ushort memPosition = 0;
            while (memPosition < this.EXT_PMEM.Length)
            {

                switch (this.EXT_PMEM[memPosition].Data)
                {
                    #region dupny switch
                    //NOP
                    case 0x00:
                        c.SetCommand(new x00(), memPosition);
                        break;
                    //AJMP page0
                    case 0x01:
                        c.SetCommand(new x01(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //LJMP code addr
                    case 0x02:

                        break;
                    //RR A
                    case 0x03:

                        break;
                    //INC A
                    case 0x04:
                        c.SetCommand(new x04(this), memPosition);
                        break;
                    //INC iram
                    case 0x05:
                        c.SetCommand(new x05(this.EXT_PMEM[memPosition].Data, this), memPosition);
                        break;
                    //INC @R0
                    case 0x06:
                        c.SetCommand(new x06(this), memPosition);
                        break;
                    //INC @R1
                    case 0x07:
                        c.SetCommand(new x07(this), memPosition);
                        break;
                    //INC R0
                    case 0x08:
                        c.SetCommand(new x08(this), memPosition);
                        break;
                    //INC R1
                    case 0x09:
                        c.SetCommand(new x09(this), memPosition);
                        break;
                    //INC R2
                    case 0x0a:
                        c.SetCommand(new x0A(this), memPosition);
                        break;
                    //INC R3
                    case 0x0b:
                        c.SetCommand(new x0B(this), memPosition);
                        break;
                    //INC R4
                    case 0x0c:
                        c.SetCommand(new x0C(this), memPosition);
                        break;
                    //INC R5
                    case 0x0d:
                        c.SetCommand(new x0D(this), memPosition);
                        break;
                    //INC R6
                    case 0x0e:
                        c.SetCommand(new x0E(this), memPosition);
                        break;
                    //INC R7
                    case 0x0f:
                        c.SetCommand(new x0F(this), memPosition);
                        break;
                    //JBC bitaddr, reladdr
                    case 0x10:

                        break;
                    //ACALL page0
                    case 0x11:
                        c.SetCommand(new x11(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //LCALL code addr
                    case 0x12:

                        break;
                    //RRC A
                    case 0x13:

                        break;
                    //DEC A
                    case 0x14:
                        c.SetCommand(new x14(this), memPosition);
                        break;
                    //DEC iram
                    case 0x15:
                        c.SetCommand(new x15(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //DEC @R0
                    case 0x16:
                        c.SetCommand(new x16(this), memPosition);
                        break;
                    //DEC @R1
                    case 0x17:
                        c.SetCommand(new x17(this), memPosition);
                        break;
                    //DEC R0
                    case 0x18:
                        c.SetCommand(new x18(this), memPosition);
                        break;
                    //DEC R1
                    case 0x19:
                        c.SetCommand(new x19(this), memPosition);
                        break;
                    //DEC R2
                    case 0x1a:
                        c.SetCommand(new x1A(this), memPosition);
                        break;
                    //DEC R3
                    case 0x1b:
                        c.SetCommand(new x1B(this), memPosition);
                        break;
                    //DEC R4
                    case 0x1c:
                        c.SetCommand(new x1C(this), memPosition);
                        break;
                    //DEC R5
                    case 0x1d:
                        c.SetCommand(new x1D(this), memPosition);
                        break;
                    //DEC R6
                    case 0x1e:
                        c.SetCommand(new x1E(this), memPosition);
                        break;
                    //DEC R7
                    case 0x1f:
                        c.SetCommand(new x1F(this), memPosition);
                        break;
                    //JB bitaddr, reladdr
                    case 0x20:

                        break;
                    // AJMP page1
                    case 0x21:

                        break;
                    // RET -
                    case 0x22:

                        break;
                    //RL A
                    case 0x23:

                        break;
                    //ADD A, #data
                    case 0x24:
                        c.SetCommand(new x24(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ADD A, iram
                    case 0x25:
                        c.SetCommand(new x25(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ADD A, @R0
                    case 0x26:
                        c.SetCommand(new x26(this), memPosition);
                        break;
                    //ADD A, @R1
                    case 0x27:
                        c.SetCommand(new x27(this), memPosition);
                        break;
                    //ADD A, R0
                    case 0x28:
                        c.SetCommand(new x28(this), memPosition);
                        break;
                    //ADD A, R1
                    case 0x29:
                        c.SetCommand(new x29(this), memPosition);
                        break;
                    //ADD A, R2
                    case 0x2a:
                        c.SetCommand(new x2A(this), memPosition);
                        break;
                    //ADD A, R3
                    case 0x2b:
                        c.SetCommand(new x2B(this), memPosition);
                        break;
                    //ADD A, R4
                    case 0x2c:
                        c.SetCommand(new x2C(this), memPosition);
                        break;
                    //ADD A, R5
                    case 0x2d:
                        c.SetCommand(new x2D(this), memPosition);
                        break;
                    //ADD A, R6
                    case 0x2e:
                        c.SetCommand(new x2E(this), memPosition);
                        break;
                    //ADD A, R7
                    case 0x2f:
                        c.SetCommand(new x2F(this), memPosition);
                        break;
                    //JNB bitaddr, reladdr
                    case 0x30:

                        break;
                    //ACALL page1
                    case 0x31:
                        c.SetCommand(new x31(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //RETI
                    case 0x32:

                        break;
                    //RLC A
                    case 0x33:

                        break;
                    //ADDC A, #data
                    case 0x34:
                        c.SetCommand(new x34(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ADDC A, iram
                    case 0x35:
                        c.SetCommand(new x35(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ADDC A, @R0
                    case 0x36:
                        c.SetCommand(new x36(this), memPosition);
                        break;
                    //ADDC A, @R1
                    case 0x37:
                        c.SetCommand(new x37(this), memPosition);
                        break;
                    //ADDC A, R0
                    case 0x38:
                        c.SetCommand(new x38(this), memPosition);
                        break;
                    //ADDC A, R1
                    case 0x39:
                        c.SetCommand(new x39(this), memPosition);
                        break;
                    //ADDC A, R2
                    case 0x3a:
                        c.SetCommand(new x3A(this), memPosition);
                        break;
                    //ADDC A, R3
                    case 0x3b:
                        c.SetCommand(new x3B(this), memPosition);
                        break;
                    //ADDC A, R4
                    case 0x3c:
                        c.SetCommand(new x3C(this), memPosition);
                        break;
                    //ADDC A, R5
                    case 0x3d:
                        c.SetCommand(new x3D(this), memPosition);
                        break;
                    //ADDC A, R6
                    case 0x3e:
                        c.SetCommand(new x3E(this), memPosition);
                        break;
                    //ADDC A, R7
                    case 0x3f:
                        c.SetCommand(new x3F(this), memPosition);
                        break;
                    //JC reladdr
                    case 0x40:

                        break;
                    //AJMP page2
                    case 0x41:
                        c.SetCommand(new x41(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ORL iram, A
                    case 0x42:
                        c.SetCommand(new x42(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //ORL iram, #data
                    case 0x43:
                        c.SetCommand(new x43(this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data, this), memPosition);
                        break;
                    //ORL A, #data
                    case 0x44:
                        c.SetCommand(new x44(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ORL A, iram
                    case 0x45:
                        c.SetCommand(new x45(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ORL A, @R0
                    case 0x46:
                        c.SetCommand(new x46(this), memPosition);
                        break;
                    //ORL A, @R1
                    case 0x47:
                        c.SetCommand(new x47(this), memPosition);
                        break;
                    //ORL A, R0
                    case 0x48:
                        c.SetCommand(new x48(this), memPosition);
                        break;
                    //ORL A, R1
                    case 0x49:
                        c.SetCommand(new x49(this), memPosition);
                        break;
                    //ORL A, R2
                    case 0x4a:
                        c.SetCommand(new x4A(this), memPosition);
                        break;
                    //ORL A, R3
                    case 0x4b:
                        c.SetCommand(new x4B(this), memPosition);
                        break;
                    //ORL A, R4
                    case 0x4c:
                        c.SetCommand(new x4C(this), memPosition);
                        break;
                    //ORL A, R5
                    case 0x4d:
                        c.SetCommand(new x4D(this), memPosition);
                        break;
                    //ORL A, R6
                    case 0x4e:
                        c.SetCommand(new x4E(this), memPosition);
                        break;
                    //ORL A, R7
                    case 0x4f:
                        c.SetCommand(new x4F(this), memPosition);
                        break;
                    //JNC reladdr
                    case 0x50:

                        break;
                    //ACALL page2
                    case 0x51:
                        c.SetCommand(new x51(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ANL iram, A
                    case 0x52:
                        c.SetCommand(new x52(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //ANL iram, #data
                    case 0x53:
                        c.SetCommand(new x53(this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data, this), memPosition);
                        break;
                    //ANL A, #data
                    case 0x54:
                        c.SetCommand(new x54(this, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //ANL A, iram
                    case 0x55:
                        c.SetCommand(new x55(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ANL a, @R0
                    case 0x56:
                        c.SetCommand(new x56(this), memPosition);
                        break;
                    //ANL a, @R1
                    case 0x57:
                        c.SetCommand(new x57(this), memPosition);
                        break;
                    //ANL a, R0
                    case 0x58:
                        c.SetCommand(new x58(this), memPosition);
                        break;
                    //ANL a, R1
                    case 0x59:
                        c.SetCommand(new x59(this), memPosition);
                        break;
                    //ANL a, R2
                    case 0x5a:
                        c.SetCommand(new x5A(this), memPosition);
                        break;
                    //ANL a, R3
                    case 0x5b:
                        c.SetCommand(new x5B(this), memPosition);
                        break;
                    //ANL a, R4
                    case 0x5c:
                        c.SetCommand(new x5C(this), memPosition);
                        break;
                    //ANL a, R5
                    case 0x5d:
                        c.SetCommand(new x5D(this), memPosition);
                        break;
                    //ANL a, R6 
                    case 0x5e:
                        c.SetCommand(new x5E(this), memPosition);
                        break;
                    //ANL a, R7
                    case 0x5f:
                        c.SetCommand(new x5F(this), memPosition);
                        break;
                    //JZ reladdr
                    case 0x60:

                        break;
                    //AJMP page3
                    case 0x61:
                        c.SetCommand(new x61(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //XRL iram, A
                    case 0x62:
                        c.SetCommand(new x62(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //XRL iram, #data
                    case 0x63:
                        c.SetCommand(new x63(this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data, this), memPosition);
                        break;
                    //XRL A, #data 
                    case 0x64:
                        c.SetCommand(new x64(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //XRL A, iram
                    case 0x65:
                        c.SetCommand(new x65(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //XRL A, @R0
                    case 0x66:
                        c.SetCommand(new x66(this), memPosition);
                        break;
                    //XRL A, @R1
                    case 0x67:
                        c.SetCommand(new x67(this), memPosition);
                        break;
                    //XRL A, R0
                    case 0x68:
                        c.SetCommand(new x68(this), memPosition);
                        break;
                    //XRL A, R1
                    case 0x69:
                        c.SetCommand(new x69(this), memPosition);
                        break;
                    //XRL A, R2
                    case 0x6a:
                        c.SetCommand(new x6A(this), memPosition);
                        break;
                    //XRL A, R3
                    case 0x6b:
                        c.SetCommand(new x6B(this), memPosition);
                        break;
                    //XRL A, R4
                    case 0x6c:
                        c.SetCommand(new x6C(this), memPosition);
                        break;
                    //XRL A, R5
                    case 0x6d:
                        c.SetCommand(new x6D(this), memPosition);
                        break;
                    //XRL A, R6
                    case 0x6e:
                        c.SetCommand(new x6E(this), memPosition);
                        break;
                    //XRL A, R7
                    case 0x6f:
                        c.SetCommand(new x6F(this), memPosition);
                        break;
                    //JNZ reladdr
                    case 0x70:

                        break;
                    //ACALL page3
                    case 0x71:
                        c.SetCommand(new x71(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ORL C, bitaddr
                    case 0x72:

                        break;
                    //JMP @a+dptr
                    case 0x73:

                        break;
                    //MOV A, #data
                    case 0x74:
                        c.SetCommand(new x74(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, #data
                    case 0x75:
                        c.SetCommand(new x75(this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data, this), memPosition);
                        break;
                    //MOV @R0, #data
                    case 0x76:
                        c.SetCommand(new x76(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV @R1, #data
                    case 0x77:
                        c.SetCommand(new x77(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R0, #data
                    case 0x78:
                        c.SetCommand(new x78(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R1, #data
                    case 0x79:
                        c.SetCommand(new x79(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R2, #data
                    case 0x7a:
                        c.SetCommand(new x7A(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R3, #data
                    case 0x7b:
                        c.SetCommand(new x7B(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R4, #data
                    case 0x7c:
                        c.SetCommand(new x7C(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R5, #data
                    case 0x7d:
                        c.SetCommand(new x7D(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R6, #data
                    case 0x7e:
                        c.SetCommand(new x7E(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R7, #data
                    case 0x7f:
                        c.SetCommand(new x7F(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //SJMP reladdr
                    case 0x80:

                        break;
                    //AJMP page4
                    case 0x81:
                        c.SetCommand(new x81(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //ANL C, bitaddr
                    case 0x82:

                        break;
                    //MOVC A, @A+DPTR
                    case 0x83:
                        c.SetCommand(new x83(this), memPosition);
                        break;
                    //DIV A, B
                    case 0x84:
                        c.SetCommand(new x84(this), memPosition);
                        break;
                    //MOV iram, iram
                    case 0x85:
                        c.SetCommand(new x85(this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data, this), memPosition);
                        break;
                    //MOV iram, @R0
                    case 0x86:
                        c.SetCommand(new x86(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, @R1
                    case 0x87:
                        c.SetCommand(new x87(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R0
                    case 0x88:
                        c.SetCommand(new x88(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R1
                    case 0x89:
                        c.SetCommand(new x89(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R2
                    case 0x8a:
                        c.SetCommand(new x8A(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R3
                    case 0x8b:
                        c.SetCommand(new x8B(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R4
                    case 0x8c:
                        c.SetCommand(new x8B(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R5
                    case 0x8d:
                        c.SetCommand(new x8D(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R6
                    case 0x8e:
                        c.SetCommand(new x8E(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV iram, R7
                    case 0x8f:
                        c.SetCommand(new x8F(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV DPTR, #data16
                    case 0x90:
                        ushort arg = Convert.ToUInt16(this.EXT_PMEM[memPosition + 1].Data.ToString() + this.EXT_PMEM[memPosition + 2].Data.ToString());
                        c.SetCommand(new x90(arg, this), memPosition);
                        break;
                    //ACALL page4
                    case 0x91:

                        break;
                    //MOV bitaddr, C
                    case 0x92:

                        break;
                    //MOVC A, @A+PC
                    case 0x93:
                        c.SetCommand(new x93(this), memPosition);
                        break;
                    //SUBB A, #data
                    case 0x94:
                        c.SetCommand(new x94(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //SUBB A, iram
                    case 0x95:
                        c.SetCommand(new x95(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //SUBB A, @R0
                    case 0x96:
                        c.SetCommand(new x96(this), memPosition);
                        break;
                    //SUBB A, @R1
                    case 0x97:
                        c.SetCommand(new x97(this), memPosition);
                        break;
                    //SUBB A, R0
                    case 0x98:
                        c.SetCommand(new x98(this), memPosition);
                        break;
                    //SUBB A, R1
                    case 0x99:
                        c.SetCommand(new x99(this), memPosition);
                        break;
                    //SUBB A, R2
                    case 0x9a:
                        c.SetCommand(new x9A(this), memPosition);
                        break;
                    //SUBB A, R3
                    case 0x9b:
                        c.SetCommand(new x9B(this), memPosition);
                        break;
                    //SUBB A, R4
                    case 0x9c:
                        c.SetCommand(new x9C(this), memPosition);
                        break;
                    //SUBB A, R5
                    case 0x9d:
                        c.SetCommand(new x9D(this), memPosition);
                        break;
                    //SUBB A, R6
                    case 0x9e:
                        c.SetCommand(new x9E(this), memPosition);
                        break;
                    //SUBB A, R7
                    case 0x9f:
                        c.SetCommand(new x9F(this), memPosition);
                        break;
                    //ORL C, bitaddr
                    case 0xa0:

                        break;
                    //AJMP page5
                    case 0xa1:
                        c.SetCommand(new x1A(this), memPosition);
                        break;
                    //MOV C, bitaddr
                    case 0xa2:

                        break;
                    //INC DPTR
                    case 0xa3:
                        c.SetCommand(new xA3(this), memPosition);
                        break;
                    //MUL A, B
                    case 0xa4:
                        c.SetCommand(new xA4(this), memPosition);
                        break;
                    //?
                    case 0xa5:

                        break;
                    //MOV @R0, iram
                    case 0xa6:
                        c.SetCommand(new xA6(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV @R1, iram
                    case 0xa7:
                        c.SetCommand(new xA7(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R0, iram
                    case 0xa8:
                        c.SetCommand(new xA8(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R1, iram
                    case 0xa9:
                        c.SetCommand(new xA9(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R2, iram
                    case 0xaa:
                        c.SetCommand(new xAA(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R3, iram
                    case 0xab:
                        c.SetCommand(new xAB(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R4, iram
                    case 0xac:
                        c.SetCommand(new xAC(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R5, iram
                    case 0xad:
                        c.SetCommand(new xAD(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R6, iram
                    case 0xae:
                        c.SetCommand(new xAE(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV R7, iram
                    case 0xaf:
                        c.SetCommand(new xAF(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //ANL C, bitaddr
                    case 0xb0:

                        break;
                    //ACALL page5
                    case 0xb1:
                        c.SetCommand(new xB1(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //CPL bitaddr
                    case 0xb2:

                        break;
                    //CPL C
                    case 0xb3:

                        break;
                    //CJNE A, #data, reladdr
                    case 0xb4:
                        c.SetCommand(new xB4(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE A, iram
                    case 0xb5:
                        c.SetCommand(new xB5(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE @R0, #data
                    case 0xb6:
                        c.SetCommand(new xB6(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE @R1, #data
                    case 0xb7:
                        c.SetCommand(new xB7(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R0, #data
                    case 0xb8:
                        c.SetCommand(new xB8(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R1, #data
                    case 0xb9:
                        c.SetCommand(new xB9(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R2, #data
                    case 0xba:
                        c.SetCommand(new xBA(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R3, #data
                    case 0xbb:
                        c.SetCommand(new xBB(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R4, #data
                    case 0xbc:
                        c.SetCommand(new xBC(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R5, #data
                    case 0xbd:
                        c.SetCommand(new xBD(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R6, #data 
                    case 0xbe:
                        c.SetCommand(new xBE(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //CJNE R7, #data
                    case 0xbf:
                        c.SetCommand(new xBF(this, this.EXT_PMEM[memPosition + 1].Data, this.EXT_PMEM[memPosition + 2].Data), memPosition);
                        break;
                    //PUSH iram
                    case 0xc0:
                        
                        break;
                    //AJMP page6
                    case 0xc1:
                        c.SetCommand(new xC1(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //CLR bitaddr
                    case 0xc2:
                        
                        break;
                    //CLR C
                    case 0xc3:
                        c.SetCommand(new xC3(this), memPosition);
                        break;
                    //SWAP A
                    case 0xc4:
                        c.SetCommand(new xC4(this), memPosition);
                        break;
                    //XCH A, iram
                    case 0xc5:
                        c.SetCommand(new xC5(this, this.EXT_PMEM[memPosition + 1].Data), memPosition);
                        break;
                    //XCH A, @R0
                    case 0xc6:
                        c.SetCommand(new xC6(this), memPosition);
                        break;
                    //XCH A, @R1
                    case 0xc7:
                        c.SetCommand(new xC7(this), memPosition);
                        break;
                    //XCH A, R0
                    case 0xc8:
                        c.SetCommand(new xC8(this), memPosition);
                        break;
                    //XCH A, R1
                    case 0xc9:
                        c.SetCommand(new xC9(this), memPosition);
                        break;
                    //XCH A, R2
                    case 0xca:
                        c.SetCommand(new xCA(this), memPosition);
                        break;
                    //XCH A, R3
                    case 0xcb:
                        c.SetCommand(new xCB(this), memPosition);
                        break;
                    //XCH A, R4
                    case 0xcc:
                        c.SetCommand(new xCC(this), memPosition);
                        break;
                    //XCH A, R5
                    case 0xcd:
                        c.SetCommand(new xCD(this), memPosition);
                        break;
                    //XCH A, R6
                    case 0xce:
                        c.SetCommand(new xCE(this), memPosition);
                        break;
                    //XCH A, R7
                    case 0xcf:
                        c.SetCommand(new xCF(this), memPosition);
                        break;
                    //POP iram
                    case 0xd0:

                        break;
                    //ACALL page6
                    case 0xd1:
                        c.SetCommand(new xD1(this,this.EXT_PMEM[memPosition+1].Data), memPosition);
                        break;
                    //SETB bitaddr
                    case 0xd2:
                        
                        break;
                    //SETB C
                    case 0xd3:
                        
                        break;
                    //DA A
                    case 0xd4:

                        break;
                    //DJNZ iram, reladdr
                    case 0xd5:

                        break;
                    //XCHD A, @R0
                    case 0xd6:
                        
                        break;
                    //XCHD A, @R1
                    case 0xd7:

                        break;
                    //DJNZ R0, reladdr
                    case 0xd8:

                        break;
                    //DJNZ R1, reladdr
                    case 0xd9:

                        break;
                    //DJNZ R2, reladdr
                    case 0xda:

                        break;
                    //DJNZ R3, reladdr
                    case 0xdb:

                        break;
                    //DJNZ R4, reladdr
                    case 0xdc:

                        break;
                    //DJNZ R5, reladdr
                    case 0xdd:

                        break;
                    //DJNZ R6, reladdr
                    case 0xde:

                        break;
                    //DJNZ R7, reladdr
                    case 0xdf:

                        break;
                    //MOVX A, @dptr
                    case 0xe0:
                        
                        break;
                    //AJMP page7
                    case 0xe1:
                        
                        break;
                    //MOVX A, @R0
                    case 0xe2:

                        break;
                    //MOVX A, @R1
                    case 0xe3:

                        break;
                    //CLR A
                    case 0xe4:
                        c.SetCommand(new xE4(this), memPosition);
                        break;
                    //MOV A, iram
                    case 0xe5:
                        c.SetCommand(new xE5(this.EXT_PMEM[memPosition+1].Data,this), memPosition);
                        break;
                    //MOV A, @R0
                    case 0xe6:
                        c.SetCommand(new xE6(this), memPosition);
                        break;
                    //MOV A, @R1
                    case 0xe7:
                        c.SetCommand(new xE7(this), memPosition);
                        break;
                    //MOV A, R0
                    case 0xe8:
                        c.SetCommand(new xE8(this), memPosition);
                        break;
                    //MOV A, R1
                    case 0xe9:
                        c.SetCommand(new xE8(this), memPosition);
                        break;
                    //MOV A, R2
                    case 0xea:
                        c.SetCommand(new xEA(this), memPosition);
                        break;
                    //MOV A, R3
                    case 0xeb:
                        c.SetCommand(new xEB(this), memPosition);
                        break;
                    //MOV A, R4
                    case 0xec:
                        c.SetCommand(new xEC(this), memPosition);
                        break;
                    //MOV A, R5
                    case 0xed:
                        c.SetCommand(new xED(this), memPosition);
                        break;
                    //MOV A, R6
                    case 0xee:
                        c.SetCommand(new xEF(this), memPosition);
                        break;
                    //MOV A, R7
                    case 0xef:
                        c.SetCommand(new xEF(this), memPosition);
                        break;
                    //MOVX @DPTR, A
                    case 0xf0:
                        
                        break;
                    //ACALL page7
                    case 0xf1:
                        c.SetCommand(new xF1(this,this.EXT_PMEM[memPosition+1].Data), memPosition);
                        break;
                    //MOVX @R0, A
                    case 0xf2:

                        break;
                    //MOVX @R1, A
                    case 0xf3:

                        break;
                    //CPL A
                    case 0xf4:

                        break;
                    //MOV iram, A
                    case 0xf5:
                        c.SetCommand(new xF5(this.EXT_PMEM[memPosition + 1].Data, this), memPosition);
                        break;
                    //MOV @R0, A
                    case 0xf6:
                        c.SetCommand(new xF6(this), memPosition);
                        break;
                    //MOV @R1, A
                    case 0xf7:
                        c.SetCommand(new xF7(this), memPosition);
                        break;
                    //MOV R0, A
                    case 0xf8:
                        c.SetCommand(new xF8(this), memPosition);
                        break;
                    //MOV R1, A
                    case 0xf9:
                        c.SetCommand(new xF9(this), memPosition);
                        break;
                    //MOV R2, A
                    case 0xfa:
                        c.SetCommand(new xFA(this), memPosition);
                        break;
                    //MOV R3, A
                    case 0xfb:
                        c.SetCommand(new xFB(this), memPosition);
                        break;
                    //MOV R4, A
                    case 0xfc:
                        c.SetCommand(new xFC(this), memPosition);
                        break;
                    //MOV R5, A
                    case 0xfd:
                        c.SetCommand(new xFD(this), memPosition);
                        break;
                    //MOV R6, A
                    case 0xfe:
                        c.SetCommand(new xFE(this), memPosition);
                        break;
                    //MOV R7, A
                    case 0xff:
                        c.SetCommand(new xFF(this), memPosition);
                        break;
                    #endregion
                }
                int j = memPosition + EXT_PMEM[memPosition].Instruction.Bytes;
                for (int i = memPosition + 1; i <= j; i++)
                {
                    EXT_PMEM[i].Instruction = new Data();
                    memPosition++;
                }
                //memPosition += Convert.ToUInt16(this.EXT_PMEM[memPosition].Instruction.Bytes - 1);
            };
            c.Run();
        }
    }
}
