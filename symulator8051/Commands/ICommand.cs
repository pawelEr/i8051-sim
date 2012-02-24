using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{
    interface ICommand
    {
        byte Cycles { get; } //ilosc cykli przez ktore bedzie wykonywany rozkaz
        ushort Bytes { get; } //dlugość instrukcji
        void execute(); //instrukcje wykonujące rozkaz
    }
}
