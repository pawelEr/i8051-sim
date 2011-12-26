using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

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
            if (commands * sleep > magiczna_granica)
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
                    Sleep();
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
        }
    }
}
