using System.Collections.Generic;

namespace spp_1
{
    interface ITracer
    {
        // вызывается в начале замеряемого метода
        void StartTrace();

        // вызывается в конце замеряемого метода 
        void StopTrace();
    
    // получить результаты измерений  
        TraceResult GetTraceResult();
    }
}
