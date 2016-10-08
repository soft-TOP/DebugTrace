using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DebugTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 i = 10;
            Debug.WriteLine(i);
            Debug.WriteLineIf(i == 10, "Der Wert passt");
            //Debug.Assert(i == 5);

            Debug.Print(i.ToString());
            Debug.Indent();
            Debug.Print(i.ToString());
            Debug.IndentSize = 10;
            Debug.Indent();

            Debug.Fail("HäH");

            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);
            Debug.WriteLine(i);

            String filename = Path.GetTempFileName();
            Debug.WriteLine(filename);
            TextWriterTraceListener myText = new TextWriterTraceListener(filename);
            Debug.Listeners.Add(myText);

            Debug.WriteLine(String.Format("Erster Versuch {0}", i));
            Debug.Unindent();
            Debug.WriteLine($"Das ist die Zahl {i}");
            Debug.Print(i.ToString());
            Debug.Flush();

            Console.ReadLine();


            // TraceSource tr = new TraceSource("mm");
            
        }
    }
}
