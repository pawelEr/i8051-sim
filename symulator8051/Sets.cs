using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace symulator8051
{
    static class Sets
    {
        static private int commands = 5; //taktowanie 
        static public int Commands
        {
            get { return commands; }
            set { commands = value;  }
        }
        static private int sleep = 500; //czas odświerzania gui
        static public int Sleep
        {
            get { return sleep; }
            set { sleep = value; }
        }
    }
}
