using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Timers;

namespace symulator8051
{
    class GuiDataValues : INotifyPropertyChanged
    {
        I8051 i;
        Timer t;
        public GuiDataValues(I8051 i)
        {
            this.i = i;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private byte acc;
        public byte ACC
        {
            get { return acc; }
            set
            {
                acc = value;
                OnPropertyChanged("ACC");
            }
        }
        private ushort dptr;
        public ushort DPTR
        {
            get { return dptr; }
            set
            {
                dptr = value;
                OnPropertyChanged("DPTR");
            }
        }
        private byte dph;

        public byte DPH
        {
            get { return dph; }
            set
            {
                dph = value;
                OnPropertyChanged("DPH");
            }
        }
        private byte dpl;

        public byte DPL
        {
            get { return dpl; }
            set
            {
                dpl = value;
                OnPropertyChanged("DPL");
            }
        }
        private byte b;

        public byte B
        {
            get { return b; }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }
        private byte sp;

        public byte SP
        {
            get { return sp; }
            set
            {
                sp = value;
                OnPropertyChanged("SP");
            }
        }
        private byte psw;

        public byte PSW
        {
            get { return psw; }
            set
            {
                psw = value;
                OnPropertyChanged("PSW");
            }
        }
        private bool ov;

        public bool OV
        {
            get { return ov; }
            set
            {
                ov = value;
                OnPropertyChanged("OV");
            }
        }
        private bool rs0;

        public bool RS0
        {
            get { return rs0; }
            set
            {
                rs0 = value;
                OnPropertyChanged("RS0");
            }
        }
        private bool rs1;

        public bool RS1
        {
            get { return rs1; }
            set
            {
                rs1 = value;
                OnPropertyChanged("RS1");
            }
        }
        private bool f0;

        public bool F0
        {
            get { return f0; }
            set
            {
                f0 = value;
                OnPropertyChanged("F0");
            }
        }
        private bool ac;

        public bool AC
        {
            get { return ac; }
            set 
            { 
                ac = value;
                OnPropertyChanged("AC");
            }
        }
        private bool cy;

        public bool CY
        {
            get { return cy; }
            set 
            { 
                cy = value;
                OnPropertyChanged("CY");
            }
        }

        private byte p0;

        public byte P0
        {
            get { return p0; }
            set
            {
                p0 = value;
                OnPropertyChanged("P0");
            }
        }
        private byte p1;

        public byte P1
        {
            get { return p1; }
            set
            {
                p1 = value;
                OnPropertyChanged("P1");
            }
        }
        private byte p2;

        public byte P2
        {
            get { return p2; }
            set
            {
                p2 = value;
                OnPropertyChanged("P2");
            }
        }
        private byte p3;

        public byte P3
        {
            get { return p3; }
            set
            {
                p3 = value;
                OnPropertyChanged("P3");
            }
        }
        private byte ie;

        public byte IE
        {
            get { return ie; }
            set
            {
                ie = value;
                OnPropertyChanged("IE");
            }
        }
        private byte ip;

        public byte IP
        {
            get { return ip; }
            set
            {
                ip = value;
                OnPropertyChanged("IP");
            }
        }
        private byte r0;

        public byte R0
        {
            get { return r0; }
            set
            {
                r0 = value;
                OnPropertyChanged("R0");
            }
        }
        private byte r1;

        public byte R1
        {
            get { return r1; }
            set
            {
                r1 = value;
                OnPropertyChanged("R1");
            }
        }
        private byte r2;

        public byte R2
        {
            get { return r2; }
            set
            {
                r2 = value;
                OnPropertyChanged("R2");
            }
        }
        private byte r3;

        public byte R3
        {
            get { return r3; }
            set
            {
                r3 = value;
                OnPropertyChanged("R3");
            }
        }
        private byte r4;

        public byte R4
        {
            get { return r4; }
            set
            {
                r4 = value;
                OnPropertyChanged("R4");
            }
        }
        private byte r5;

        public byte R5
        {
            get { return r5; }
            set
            {
                r5 = value;
                OnPropertyChanged("R5");
            }
        }
        private byte r6;

        public byte R6
        {
            get { return r6; }
            set
            {
                r6 = value;
                OnPropertyChanged("R6");
            }
        }
        private byte r7;

        public byte R7
        {
            get { return r7; }
            set
            {
                r7 = value;
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
        private byte tl0;

        public byte TL0
        {
            get { return tl0; }
            set 
            { 
                tl0 = value;
                OnPropertyChanged("TL0");
            }
        }
        private byte th0;

        public byte TH0
        {
            get { return th0; }
            set 
            { 
                th0 = value;
                OnPropertyChanged("TH0");
            }
        }
        private byte tl1;

        public byte TL1
        {
            get { return tl1; }
            set 
            { 
                tl1 = value;
                OnPropertyChanged("TL1");
            }
        }
        private byte th1;

        public byte TH1
        {
            get { return th1; }
            set 
            { 
                th1 = value;
                OnPropertyChanged("TH1");
            }
        }

        public void UpdateFields()
        {
            this.ACC = i.ACC;
            this.DPTR = i.DPTR;
            this.DPH = i.DPH;
            this.DPL = i.DPL;
            this.B = i.B;
            this.SP = i.SP;
            this.PSW = i.PSW;
            this.OV = i.OV;
            this.RS0 = i.RS0;
            this.RS1 = i.RS1;
            this.F0 = i.F0;
            this.AC = i.AC;
            this.CY = i.CY;
            this.P0 = i.P0;
            this.P1 = i.P1;
            this.P2 = i.P2;
            this.P3 = i.P3;
            this.IE = i.IE;
            this.IP = i.IP;
            this.R0 = i.R0;
            this.R1 = i.R1;
            this.R2 = i.R2;
            this.R3 = i.R2;
            this.R4 = i.R4;
            this.R5 = i.R5;
            this.R6 = i.R6;
            this.R7 = i.R7;
            this.PC = i.PC;
            this.TL0 = i.TL0;
            this.TH0 = i.TH0;
            this.TL1 = i.TL1;
            this.TH1 = i.TH1;
        }
        public void StartUpdate()
        {
            t = new Timer();
            t.Interval = 500;
            t.Elapsed += (e, a) => UpdateFields();
            t.AutoReset = true;
            t.Enabled = true;
            t.Start();
        }
        public void StopUpdate()
        {
            t.Stop();
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
