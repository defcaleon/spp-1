using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library.Serialization
{
    [Serializable]
    [XmlType("Thread")]

    public class ResultAndThread
    {
        [XmlAttribute]
        public int id;

        [XmlAttribute]
        public double time;

        [XmlElement]
        public List<Method> method;

        public ResultAndThread(int id, double time, List<Result> method)
        {
            this.id = id;
            this.time = time;
            this.method = listIntoStructure(method);
        }

        public ResultAndThread()
        {
        }

        private List<Method> listIntoStructure(List<Result> method)
        {
            List<Method> list = new List<Method>();

            for (int i = 0; i < method.Count; i++)
            {
                List<Method> refList = list;
                var item = method[i];

                for (int j = 0; j < item.deep; j++)
                {
                    refList = refList[refList.Count - 1].list;
                }

                refList.Add(new Method(item));
            }
            return list;
        }
    }
}
