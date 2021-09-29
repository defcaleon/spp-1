using Library;

using NUnit.Framework;
using spp_1;
using System.Threading;


namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class UnitTest1
        {
            public Tracer tracer;
            int id;

            [SetUp]
            public void Setup()
            {
                tracer = Tracer.getInstance();
                id = Thread.CurrentThread.ManagedThreadId;
            }

            [Test]
            public void TestSingleThread()
            {
                var bar = new Bar(tracer);
                bar.InnerMethod();
                var result = tracer.GetTraceResult();

                Assert.AreEqual(true, result.getResult().ContainsKey(id));
            }

            [Test]
            public void TestSingleMethodAndClass()
            {
                var bar = new Bar(tracer);
                bar.InnerMethod();
                var result = tracer.GetTraceResult();

                
                Assert.AreEqual(nameof(bar.InnerMethod), result.getResult()[id][0].methodName);
                Assert.AreEqual("spp_1.Bar", result.getResult()[id][0].className);
            }

            [Test]
            public void TestInnerMethod()
            {
                var foo = new Foo(tracer);
                foo.MyMethod();
                var result = tracer.GetTraceResult();

                Assert.AreEqual("spp_1.Foo", result.getResult()[id][0].className);
                Assert.AreEqual("MyMethod", result.getResult()[id][0].methodName);
            }

            [Test]
            public void TestTwoThreads()
            {
                var bar = new Bar(tracer);
                bar.InnerMethod();
                var result = tracer.GetTraceResult();

                Assert.AreEqual(true, result.getResult()[id] != null);

                var bar2 = new Bar(tracer);
                Thread thread = new Thread(new ThreadStart(bar2.InnerMethod));
                int id2 = thread.ManagedThreadId;
                thread.Start();
                thread.Join();
                Assert.AreEqual(true, result.getResult()[id2] != null);
                Assert.AreEqual(2, result.getResult().Count);
            }

            [Test]
            public void TestTwoThreadsAndInnerMethods()
            {
                var foo = new Foo(tracer);
                foo.MyMethod();
                foo.MyMethod();
                var result = tracer.GetTraceResult();

                Assert.AreEqual(true, result.getResult()[id] != null);
                Assert.AreEqual(false, result.getResult()[id][0].methodName == result.getResult()[id][1].methodName);

                var foo2 = new Foo(tracer);
                Thread thread = new Thread(new ThreadStart(foo.MyMethod));
                int id2 = thread.ManagedThreadId;
                thread.Start();
                thread.Join();
                Assert.AreEqual(true, result.getResult()[id2] != null);

                Assert.AreEqual(nameof(foo.MyMethod), result.getResult()[id][0].methodName);
            }
        }
    }
}