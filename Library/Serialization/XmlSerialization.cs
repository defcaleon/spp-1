using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Library.Serialization
{
    public class XmlSerialization : ISerialization
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



            XmlSerializer formatter = new XmlSerializer(typeof(List<ResultAndThread>));
            formatter.Serialize(output, list);
        }
    }
}
