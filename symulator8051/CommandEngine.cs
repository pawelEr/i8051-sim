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
        List<ICommand> commands;
        Thread commandsThread;
        I8051 i;
        bool pause = false;
        public CommandEngine(I8051 i8051)
        {
            commands = new List<ICommand>();
            i = i8051;
        }
        public void AddCommand(ICommand item)
        {
            commands.Add(item);
        }
        private void CycleCommands()
        {
            ushort pcs = Convert.ToUInt16(commands.Count);
            while (i.PC<pcs)
            {
                commands[i.PC].execute();
                if (pause)
                    commandsThread.Suspend();
            }
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
        public void ClearCommandList()
        {
            commands.Clear();
        }
        public void OneStep()
        {
            commandsThread.Resume();
        }
    }
}
