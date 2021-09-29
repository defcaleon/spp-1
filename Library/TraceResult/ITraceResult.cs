using System.Collections.Generic;

namespace Library
{
    public interface ITraceResult
    {
        public Dictionary<int, List<Result>> getResult();
    }
}
