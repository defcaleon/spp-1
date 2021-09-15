using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace spp_1.Tracer
{
    class Tracer : ITracer
    {
        private Stopwatch stopwatch;
        private TraceResult traceResult;

        public Tracer()
        {
            this.stopwatch = new Stopwatch();
            this.traceResult = new TraceResult();
        }

        public TraceResult GetTraceResult()
        {
            throw new NotImplementedException();
        }

        public void StartTrace()
        {
            throw new NotImplementedException();
        }

        public void StopTrace()
        {
            throw new NotImplementedException();
        }
    }
}
