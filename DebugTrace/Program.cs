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
            /*
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

*/

            SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", SourceLevels.Verbose.ToString());
/*
            Console.WriteLine(sourceSwitch.Attributes.Values);
            Console.WriteLine(sourceSwitch.Description);
            Console.WriteLine(sourceSwitch.DisplayName);
            Console.WriteLine(sourceSwitch.Level);
            Console.WriteLine(sourceSwitch.ShouldTrace(TraceEventType.Information));
            Console.WriteLine(sourceSwitch.ToString());
*/

            //            sourceSwitch.Level = SourceLevels.Information;

            TraceSource tr = new TraceSource("TOP", SourceLevels.All);


            //TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            DelimitedListTraceListener myWriter = new DelimitedListTraceListener(System.Console.Out);
            myWriter.IndentLevel = 1;
            myWriter.IndentSize = 5;
            myWriter.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Timestamp;
            myWriter.Fail("Fehler", "Detail");


            tr.Listeners.Add(myWriter);

            Console.WriteLine(tr.Switch.Level.ToString());

            tr.TraceData(TraceEventType.Information, 500, tr.Switch);
            tr.TraceEvent(TraceEventType.Information, 501);
            tr.TraceData(TraceEventType.Error, 500, tr.Switch);
            tr.TraceEvent(TraceEventType.Error, 501);
            tr.TraceEvent(TraceEventType.Warning, 577);
            tr.TraceInformation("TEST");

            Guid guid = new Guid("e3382d12-7034-4826-912d-a3eaa4642324");
            tr.TraceTransfer(502, "zweiter test", guid);

            Console.WriteLine(String.Empty.PadRight(50, '#'));
            tr.Switch = sourceSwitch;
            tr.TraceData(TraceEventType.Information, 1000, tr.Switch);
            tr.TraceEvent(TraceEventType.Information, 1001);
            tr.TraceData(TraceEventType.Error, 1000, tr.Switch);
            tr.TraceEvent(TraceEventType.Error, 1001);
            tr.TraceEvent(TraceEventType.Warning, 1077);
            tr.TraceInformation("TEST");
            tr.TraceTransfer(1002, "zweiter test", guid);

            sourceSwitch.Level = SourceLevels.Warning;

            Console.WriteLine(String.Empty.PadRight(50, '-'));
            tr.Switch = sourceSwitch;
            tr.TraceData(TraceEventType.Information, 100, tr.Switch);
            tr.TraceEvent(TraceEventType.Information, 101);
            tr.TraceData(TraceEventType.Error, 100, tr.Switch);
            tr.TraceEvent(TraceEventType.Error, 101);
            tr.TraceEvent(TraceEventType.Warning, 177);
            tr.TraceInformation("TEST");
            tr.TraceTransfer(102, "zweiter test", guid);

            tr.Switch.Level = SourceLevels.Verbose;

            Console.WriteLine(String.Empty.PadRight(50, '='));
            tr.Switch = sourceSwitch;
            tr.TraceData(TraceEventType.Information, 600, tr.Switch);
            tr.TraceEvent(TraceEventType.Information, 601);
            tr.TraceData(TraceEventType.Error, 600, tr.Switch);
            tr.TraceEvent(TraceEventType.Error, 601);
            tr.TraceEvent(TraceEventType.Warning, 677);
            tr.TraceInformation("TEST");
            tr.TraceTransfer(602, "zweiter test", guid);


            Console.ReadLine();

        }
    }
}
