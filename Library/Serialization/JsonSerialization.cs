using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public void serialize(Stream output, ITraceResult resultList)
        {
            List<ResultAndThread> list = new List<ResultAndThread>();


            foreach (KeyValuePair<int, List<Result>> item in resultList.getResult())
            {
                double deltaTime = 0;
                foreach (Result time in item.Value)
                {
                    deltaTime += time.executionTime;
                }
                list.Add(new ResultAndThread(item.Key, deltaTime, item.Value));
            }



            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            var stream = new StreamWriter(output);
            stream.AutoFlush = true;
            stream.Write(json);
        }
    }
}
