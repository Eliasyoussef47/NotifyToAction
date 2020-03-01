using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class Configs : ConfigsTools
    {
        public Configs()
        {
            RegisteredTriggerSenders = new List<RegisteredTriggerSenders>();
            Test = "";
        }

        [JsonIgnore]
        public static string ConfigsFileName = "Configs.json";

        public RegisteredTrigger GetRegisteredTrigger(string senderId, string triggerId)
        {
            RegisteredTriggerSenders registeredSenderTriggers = RegisteredTriggerSenders.Find(x => x.SenderId.Equals(senderId));
            if (registeredSenderTriggers == null)
            {
                return null;
            }
            RegisteredTrigger registeredTrigger = registeredSenderTriggers.RegisteredTriggers.Find(x => x.TriggerId.Equals(triggerId));
            return registeredTrigger;
        }


        [JsonProperty("registeredTriggerSenders", Required = Required.AllowNull)]
        public List<RegisteredTriggerSenders> RegisteredTriggerSenders { get; set; }

        [JsonProperty("yeelightLampIp", Required = Required.Default)]
        public string YeelightLampIp { get; set; }

        [JsonProperty("pushbulletAccessToken", Required = Required.AllowNull)]
        public string PushbulletAccessToken { get; set; }

        [JsonProperty("test", Required = Required.AllowNull)]
        public string Test { get; set; }
    }
}
