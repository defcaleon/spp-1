using System;
using System.IO;
using System.Linq;
using System.Threading;
using Library;
using Library.Serialization;

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

            
            var consoleStream = Console.OpenStandardOutput();

            ISerialization serializator = new JsonSerialization();
            serializator.serialize(consoleStream, tracer.GetTraceResult());

            using (FileStream fs = new FileStream("ser.json", FileMode.OpenOrCreate))
            {
                serializator.serialize(fs, tracer.GetTraceResult());
            }

            serializator = new XmlSerialization();

            serializator.serialize(consoleStream, tracer.GetTraceResult());

            using (FileStream fs = new FileStream("ser.xml", FileMode.OpenOrCreate))
            {
                serializator.serialize(fs, tracer.GetTraceResult());
            }
        }
    }
}
