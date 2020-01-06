using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotifyToAction
{
    class RegisteredSenderTriggers
    {
        [JsonConstructor]
        public RegisteredSenderTriggers()
        {
            SenderId = "";
            RegisteredTriggers = new List<RegisteredTrigger>();
        }

        [JsonProperty("senderId", Order = 0, Required = Required.Always)]
        public string SenderId;

        [JsonProperty("registeredTriggers", Order = 1, Required = Required.AllowNull)]
        public List<RegisteredTrigger> RegisteredTriggers;
    }
}
