using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using ByteExtensionMethods;
using symulator8051.Commands;
using System.IO;

namespace symulator8051
{
	class CommandEngine
	{
		Thread mainThread;
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
			if (Sets.Commands > magiczna_granica) //jak jest iles instrukcji w ciagu jednego opoznienia
			{
				this.sleep = 50;
				this.commands = (Sets.Commands) / this.sleep;
			}
			else//jak jest jedna instrukcja w ciagu jednego opoznienia
			{
				this.sleep = 1000 / Sets.Commands;
			}
		}
		public void SetCommand(ICommand item, ushort memAdress) //ustawia rozkaz(obietkt rozkazu) na konkretny adres w pamieci
		{
			this.i.EXT_PMEM[memAdress].Instruction = item;
		}
		private void CycleCommands() //wykonuje ileś komend 
		{
			for (int y = 0; y < commands; y++)
			{
				this.i.EXT_PMEM[i.PC].Instruction.execute();
				this.i.PC += this.i.EXT_PMEM[i.PC].Instruction.Bytes;
				//obsluga timerow
				i.getTModValues();
				i.getTConValues();
				if (!i.T0ct || (i.T0gate && i.T0ct && i.Tie1 && !i.Tit0))
					i.pingTimer0();
				if (!i.T1ct || (i.T1gate && i.T1ct && i.Tie1 && !i.Tit1))
					i.pingTimer0();
			}
		}
		private void OneCommand() //wykonuje jedną komendę
		{
			this.i.EXT_PMEM[i.PC].Instruction.execute();
			this.i.PC = (ushort)(this.i.PC + this.i.EXT_PMEM[i.PC].Instruction.Bytes);
			//obsluga timerow
			i.getTModValues();
			i.getTConValues();
			if (!i.T0ct || (i.T0gate && i.T0ct && i.Tie1 && !i.Tit0))
				i.pingTimer0();
			if (!i.T1ct || (i.T1gate && i.T1ct && i.Tie1 && !i.Tit1))
				i.pingTimer0();
		}
		public void Run1mode() //tryb jedna komenda na opoznienie
		{
			while (!pause)
			{
				backgroundThread = new Thread(new ThreadStart(Sleep));
				backgroundThread.Name = "Background commands Thread";
				backgroundThread.Start();
				OneCommand();
				backgroundThread.Join();
			};
		}
		public void Run2mode() //tryb wiele komend na opoznienie
		{
			while (!pause)
			{
				backgroundThread = new Thread(new ThreadStart(CycleCommands));
				backgroundThread.Name = "Background commands Thread";
				backgroundThread.Start();
				SleepForManyCommands();
				backgroundThread.Join();
			}
		}
		public void Run() //start symulacji
		{
			if (commands < magiczna_granica)
			{
				mainThread = new Thread(new ThreadStart(Run1mode));

			}
			else
			{
				mainThread = new Thread(new ThreadStart(Run2mode));
			}
			mainThread.Name = "Main commands Thread";
			mainThread.Start();
		}
		public void Pause() //pauzowanie, ustawia flage ktora zatrzymuje petle wykonujace(tworzace watki z wykonywanymi instrukcjami instrukcje 
		{
			pause = true;
		}
		private void Sleep() //funkcja usypia swoj watek na wyliczony czas  na podstawie ilosci cykli i wyliczonego czasu na jeden cykl (uzywane przy jedna instrukcja - jedno opoznienie
		{
			Thread.Sleep(this.sleep * this.i.EXT_PMEM[i.PC].Instruction.Cycles);
		}
		private void SleepForManyCommands() //funckja usypia watek na okreslony czas (stosowane przy trybie wiele instrukcji na jedno opoznienie)
		{
			Thread.Sleep(this.sleep);
		}
		public void Resume()
		{
			pause = false;
			Run();
		}
		public void Stop()
		{
			try
			{
				mainThread.Abort();
			}
			catch (ThreadAbortException e)
			{
				Trace.WriteLine("Symulacja ubita, nic strasznego.");
			}
			if (File.Exists(@"temp.hex"))
				File.Delete(@"temp.hex");
			if (File.Exists(@"temp.lst"))
				File.Delete(@"temp.lst");
			if (File.Exists(@"temp.asm"))
				File.Delete(@"temp.asm");
		}
		public void OneStep()  //jeden krok do przodu - aktywne tylko po pauzie
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
