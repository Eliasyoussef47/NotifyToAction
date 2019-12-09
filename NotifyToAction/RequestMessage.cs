using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace NotifyToAction
{
    class RequestMessage : Message
    {
        [JsonProperty("senderId", Order = 1, Required = Required.Always)]
        public readonly string SenderId;
        [JsonProperty("method", Order = 2, Required = Required.Always)]
        public string Method;
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Include, Order = 3, Required = Required.AllowNull)]
        public dynamic[] Parameters;

        public void RunMethod()
        {
            Type type = typeof(MessageMethods);
            MethodInfo theMethod = type.GetMethod(Method);
            theMethod.Invoke(this, Parameters);
        }
    }
}
