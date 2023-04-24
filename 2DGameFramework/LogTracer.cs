using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2DGameFramework
{
    public class LogTracer
    {
        public TraceSource ts;
        private static LogTracer _instance = new LogTracer();
        public static LogTracer Instance { get { return _instance; } }
        private LogTracer()
        {
            ts = new TraceSource("2DGameFramework");
            ts.Switch = new SourceSwitch("Trace", "All");

            TraceListener listener = new TextWriterTraceListener(new StreamWriter("Trace.txt") { AutoFlush = true });
            ts.Listeners.Add(listener);
        }

        public void AddInfo(int eventNumber, string message)
        {
            ts.TraceEvent(TraceEventType.Information, eventNumber, message);
        }

        public void AddWarning(int eventNumber, string message)
        {
            ts.TraceEvent(TraceEventType.Warning, eventNumber, message);
        }

        public void AddError(int eventNumber, string message)
        {
            ts.TraceEvent(TraceEventType.Error, eventNumber, message);
        }

        public void AddCritical(int eventNumber, string message)
        {
            ts.TraceEvent(TraceEventType.Critical, eventNumber, message);
        }
    }



}
