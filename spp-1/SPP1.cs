using System;
using System.Collections.Generic;
using System.Linq;

namespace spp_1
{
    class SPP1
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod();


            Console.WriteLine(tracer.GetTraceResult().getResult().Count);
            var result = tracer.GetTraceResult().getResult();
            for (int i=0; i < result.Count; i++)
            {
                Console.WriteLine(result.ElementAt(i).ToString());
            }
        }
    }
}
