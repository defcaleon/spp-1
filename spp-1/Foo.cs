using Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace spp_1
{
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
            MyMethod();
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(20);

            _bar.InnerMethod();

            Thread.Sleep(20);
            _bar.InnerMethod();

            _tracer.StopTrace();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(40);
            thirdMethod();
            thirdMethod();
            _tracer.StopTrace();
        }

        public void thirdMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(40);
            _tracer.StopTrace();
        }
    }
}
