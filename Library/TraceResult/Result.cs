using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    public class Result
    {
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string methodName;
        [XmlAttribute("time")]
        [JsonProperty("time")]
        public int executionTime;
        [XmlAttribute("class")]
        [JsonProperty("class")]
        public string className;

        [JsonIgnore]
        [XmlIgnore]
        public int deep;

        public Result(string methodName, int executionTime, string className)
        {
            this.methodName = methodName;
            this.executionTime = executionTime;
            this.className = className;
        }

        public override string ToString()
        {
            return deep + " " + methodName + " " + className + " " + executionTime;
        }

        public Result()
        {
        }
    }
}
