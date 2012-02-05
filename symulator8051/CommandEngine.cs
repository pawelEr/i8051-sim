using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using ByteExtensionMethods;
using symulator8051.Commands;

namespace symulator8051
{
    class CommandEngine
    {
        Thread backgroundThread;
        I8051 i;
        bool pause = false;
        int commands, sleep;
        /*
         * magiczna granica przełączania między trybami wykonywania instrukcji
         */
        int magiczna_granica = 100;

        public CommandEngine(I8051 i8051)
        {
            this.i = i8051;
            if (Sets.Commands > magiczna_granica) //TODO: uzupełnić
            {
                this.sleep = 50;
                this.commands = Sets.Commands / this.sleep;
            }
            else
            {
                this.sleep = 1000 / Sets.Commands;
            }
        }
        public void SetCommand(ICommand item, ushort memAdress)
        {
            this.i.EXT_PMEM[memAdress].Instruction = item;
        }
        private void CycleCommands()
        {
            for (int y = 0; y < commands; y++)
            {
                this.i.EXT_PMEM[i.PC].Instruction.execute();
                this.i.PC += this.i.EXT_PMEM[i.PC].Instruction.Bytes;
            }
        }
        private void OneCommand()
        {
            this.i.EXT_PMEM[i.PC].Instruction.execute();
            this.i.PC += this.i.EXT_PMEM[i.PC].Instruction.Bytes;
        }
        public void Run()
        {
            if (commands > magiczna_granica)
            {
                while (!pause)
                {
                    backgroundThread = new Thread(new ThreadStart(Sleep));
                    backgroundThread.Start();
                    OneCommand();
                    backgroundThread.Join();
                };
            }
            else
            {
                while (!pause)
                {
                    backgroundThread = new Thread(new ThreadStart(CycleCommands));
                    backgroundThread.Start();
                    SleepForManyCommands();
                    backgroundThread.Join();
                }
            }
        }
        public void Pause()
        {
            pause = true;
        }
        private void Sleep()
        {
            Thread.Sleep(this.sleep * this.i.EXT_PMEM[i.PC].Instruction.Cycles);
        }
        private void SleepForManyCommands()
        {
            Thread.Sleep(this.sleep);
        }
        public void Resume()
        {
            pause = false;
            CycleCommands();
        }
        public void Stop()
        {
            backgroundThread.Abort();
        }
        public void OneStep()
        {
            OneCommand();
            i.getTModValues();
            i.getTConValues();
            if (!i.T0ct || (i.T0gate && i.T0ct && i.Tie1 && !i.Tit0)) 
                i.pingTimer0();
            if (!i.T1ct || (i.T1gate && i.T1ct && i.Tie1 && !i.Tit1)) 
                i.pingTimer0();
        }
    }
}
