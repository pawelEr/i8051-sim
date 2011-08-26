using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace symulator8051
{ 
    class Line
    {
        public string code;
        public string arg1;
        public string arg2;
        public string arg3;

        public Line(string a, string b, string c, string d)
        {
            this.code = a;
            this.arg1 = b;
            this.arg2 = c;
            this.arg3 = d;
        }
    }
    class SourceCode
    {
        public static string code = null;
        public List<Line> processedLines;
        public SourceCode()
        {
            foreach (string l in code.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] values = l.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                processedLines.Add(new Line(values[0], values[1], values[2], values[3]));
            }
        }

        
    }

}
