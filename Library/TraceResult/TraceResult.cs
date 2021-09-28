using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Library
{
    public class TraceResult
    {
        private Dictionary<int, List<Result>> list;

        public TraceResult()
        {
            this.list = new Dictionary<int, List<Result>>();
        }

        public void addResult(Result result, int threadID)
        {
            if (!list.ContainsKey(threadID))
            {
                list.Add(threadID, new List<Result>());
            }
            list[threadID].Add(result);
        }

        public Dictionary<int, List<Result>> getResult()
        {
            Dictionary<int, List<Result>> result = new Dictionary<int, List<Result>>();

            foreach (KeyValuePair<int, List<Result>> item in list)
            {
                result.Add(item.Key, new List<Result>(item.Value));
            }
            return result;
        }
    }
}
