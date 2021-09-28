using System;
using System.Linq;
using System.Threading;
using Library;

namespace spp_1
{
    class SPP1
    {
        static void Main(string[] args)
        {
            ITracer tracer = Tracer.getInstance();
            Foo foo = new Foo(tracer);
            foo.MyMethod();


            Thread thread = new Thread(new ThreadStart(foo.MyMethod));
            thread.Start();
            thread.Join();

            Console.WriteLine(tracer.GetTraceResult().getResult().Count);
            var result = tracer.GetTraceResult().getResult();
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("thread: " + result.ElementAt(i).Key);
                for (int j = 0; j < result.ElementAt(i).Value.Count; j++)
                {
                    Console.WriteLine(result.ElementAt(i).Value.ElementAt(j).ToString());
                }
            }
        }
    }
}
