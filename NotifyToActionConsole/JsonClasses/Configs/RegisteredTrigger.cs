using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToActionConsole
{
    class RegisteredTrigger
    {
        public RegisteredTrigger()
        {
            TriggerId = "";
            Actions = new List<RegisteredTriggerAction>();
        }

        [JsonProperty("triggerId", Required = Required.Always)]
        public string TriggerId;

        [JsonProperty("actions", Required = Required.Always)]
        public List<RegisteredTriggerAction> Actions;
    }

    class RegisteredTriggerAction
    {
        public RegisteredTriggerAction(string typeName, string methodName, List<dynamic> methodParameters)
        {
            TypeName = typeName;
            MethodName = methodName;
            MethodParameters = methodParameters;
        }

        [JsonConstructor]
        public RegisteredTriggerAction()
        {
            TypeName = "";
            MethodName = "";
            MethodParameters = new List<dynamic>();
        }

        [JsonProperty("typeName", Required = Required.Always)]
        public string TypeName;

        [JsonProperty("methodName", Required = Required.Always)]
        public string MethodName;

        [JsonProperty("methodParameters", Required = Required.AllowNull)]
        public List<dynamic> MethodParameters;
    }
}
