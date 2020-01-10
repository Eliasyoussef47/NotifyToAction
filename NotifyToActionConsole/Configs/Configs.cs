using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToActionConsole
{
    class Configs : ConfigsTools
    {
        public Configs()
        {
            RegisteredSenderTriggers = new List<RegisteredSenderTriggers>();
            Test = "";
        }

        [JsonIgnore]
        public static string ConfigsFileName = "Configs.json";

        public RegisteredTrigger GetRegisteredTrigger(string senderId, string triggerId)
        {
            RegisteredSenderTriggers registeredSenderTriggers = RegisteredSenderTriggers.Find(x => x.SenderId.Equals(senderId));
            if (registeredSenderTriggers == null)
            {
                return null;
            }
            RegisteredTrigger registeredTrigger = registeredSenderTriggers.RegisteredTriggers.Find(x => x.TriggerId.Equals(triggerId));
            return registeredTrigger;
        }


        [JsonProperty("registeredSenderTriggers")]
        public List<RegisteredSenderTriggers> RegisteredSenderTriggers { get; set; }

        [JsonProperty("test", Required = Required.AllowNull)]
        public string Test { get; set; }
    }
}
