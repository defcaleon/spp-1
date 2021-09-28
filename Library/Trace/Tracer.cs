using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Library
{
    public class Tracer : ITracer
    {

        private static Tracer instance = null;
        private static object objectlock = new object();

        private Stopwatch stopwatch;
        private TraceResult traceResult;
        private Dictionary<int, Stack<TimeSpan>> timeSpans;


        public static Tracer getInstance()
        {
            if (instance == null)
            {
                lock (objectlock)
                {
                    if (instance == null)
                    {
                        instance = new Tracer();
                    }
                }
            }
            return instance;
        }
        private Tracer()
        {
            this.stopwatch = new Stopwatch();
            this.traceResult = new TraceResult();
            this.timeSpans = new Dictionary<int, Stack<TimeSpan>>();
            stopwatch.Start();
        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            if (!timeSpans.ContainsKey(id))
            {
                timeSpans.Add(id, new Stack<TimeSpan>());
            }
            timeSpans.GetValueOrDefault(id).Push(stopwatch.Elapsed);

        }

        public void StopTrace()
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            double totalMs = timeSpan.TotalMilliseconds - timeSpans[threadId].Pop().TotalMilliseconds;

            StackTrace frame = new StackTrace(0);
            var method = frame.GetFrame(1).GetMethod();
            string className = method.DeclaringType.ToString();
            string methodName = method.Name.ToString();


            traceResult.addResult(new Result(methodName, className, totalMs), threadId);
        }
    }
}
