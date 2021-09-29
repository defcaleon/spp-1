using System.Collections.Generic;

namespace Library
{
    class TraceResult : ITraceResult
    {
        private Dictionary<int, ThreadResult> list;

        public TraceResult()
        {
            this.list = new Dictionary<int, ThreadResult>();
        }

        internal void incrementCounter(int threadID)
        {
            if (!list.ContainsKey(threadID))
            {
                list.Add(threadID, new ThreadResult());
            }
            list[threadID].incrementCounter();

        }
        internal void decrementCounter(int threadID)
        {
            if (!list.ContainsKey(threadID))
            {
                list.Add(threadID, new ThreadResult());
            }
            list[threadID].decrementCounter();

        }

        internal void addResult(Result result, int threadID)
        {
            if (!list.ContainsKey(threadID))
            {
                list.Add(threadID, new ThreadResult());
            }
            list[threadID].add(result);
        }

        public Dictionary<int, List<Result>> getResult()
        {

            Dictionary<int, List<Result>> result = new Dictionary<int, List<Result>>();

            foreach (KeyValuePair<int, ThreadResult> item in list)
            {
                result.Add(item.Key, new List<Result>(item.Value.list));
                result[item.Key].Reverse();
            }
            return result;
        }
    }
}
