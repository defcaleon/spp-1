using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace spp_1
{
    class Tracer : ITracer
    {
        private Stopwatch stopwatch;
        private TraceResult traceResult;
        private Stack<TimeSpan> timeSpans; 

        public Tracer()
        {
            this.stopwatch = new Stopwatch();
            this.traceResult = new TraceResult();
            this.timeSpans = new Stack<TimeSpan>();
            stopwatch.Start();
        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            timeSpans.Push(stopwatch.Elapsed);
        }

        public void StopTrace()
        {
            SaveAndStop();
        }

        private void SaveAndStop()
        {
            TimeSpan timeSpan = stopwatch.Elapsed;

            double totalMs = timeSpan.TotalMilliseconds - timeSpans.Pop().TotalMilliseconds;

            StackTrace frame = new StackTrace(0);
            var method = frame.GetFrame(2).GetMethod();
            string className = method.DeclaringType.ToString();
            string methodName = method.Name.ToString();

            traceResult.addResult(new Result(methodName, className, totalMs));
        }

    }
}
