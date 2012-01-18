using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace symulator8051
{
    static class Sets
    {
        static private int commands = 5;
        static public int Commands
        {
            get { return commands; }
            set { commands = value;  }
        }
        static private int sleep = 20;
        static public int Sleep
        {
            get { return sleep; }
            set { sleep = value; }
        }
    }
}
