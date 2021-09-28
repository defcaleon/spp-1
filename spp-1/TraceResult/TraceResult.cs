using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace spp_1
{
    class TraceResult
    {
        private List<Result> list;

        public TraceResult()
        {
            this.list = new List<Result>();
        }

        public void  addResult(Result result)
        {
            list.Add(result);
        }

        public List<Result> getResult()
        {
            return new List<Result>(list);
        }
    }
}
