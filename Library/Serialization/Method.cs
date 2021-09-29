using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library.Serialization
{
    [Serializable]
    public class Method
    {
        [XmlElement("method")]
        [JsonProperty("method")]
        public Result methodInfo;
        [XmlElement("childMethods")]
        [JsonProperty("childMethods")]
        public List<Method> list;

        public Method(Result methodInfo, List<Method> list)
        {
            this.methodInfo = methodInfo;
            this.list = list;
        }

        public Method(Result methodInfo)
        {
            this.methodInfo = methodInfo;
            this.list = new List<Method>();
        }

        public Method()
        {
        }

        public void add(Result result)
        {

        }
    }
}
