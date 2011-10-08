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
        Thread commandsThread;
        I8051 i;
        bool pause = false;
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
            while (!pause)
            {
                this.i.EXT_PMEM[i.PC].Instruction.execute();
            }
            commandsThread.Suspend();
        }
        public void Run()
        {
            commandsThread = new Thread(new ThreadStart(CycleCommands));
            commandsThread.Start();
        }
        public void Pause()
        {
            pause = true;
        }
        public void Resume()
        {
            pause = false;
            commandsThread.Resume();
        }
        public void Stop()
        {
            commandsThread.Abort();
        }
        public void OneStep()
        {
            commandsThread.Resume();
        }
    }
}
