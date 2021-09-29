using System.Collections.Generic;


namespace Library
{
    public class ThreadResult
    {
        public int counter;
        public List<Result> list;

        public ThreadResult()
        {
            this.counter = 0;
            this.list = new List<Result>();
        }

        public void add(Result result)
        {
            result.deep = counter;
            list.Add(result);
        }

        public void incrementCounter()
        {
            counter++;
        }

        public void decrementCounter()
        {
            counter--;
        }
    }
}
