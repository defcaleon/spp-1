using System;
using System.Collections.Generic;
using System.Text;

namespace spp_1
{
    class Result
    {
        private string methodName;
        private string className;
        private double executionTime;

        public Result(string methodName, string className, double executionTime)
        {
            this.methodName = methodName;
            this.className = className;
            this.executionTime = executionTime;
        }

        public override string ToString()
        {
            return methodName + " " + className + " " + executionTime;
        }
    }
}
