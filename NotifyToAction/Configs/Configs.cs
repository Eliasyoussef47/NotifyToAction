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


        [JsonProperty("registeredSenderTriggers", Required = Required.AllowNull)]
        public List<RegisteredSenderTriggers> RegisteredSenderTriggers { get; set; }

        [JsonProperty("yeelightLampIp", Required = Required.Default)]
        public string YeelightLampIp { get; set; }

        [JsonProperty("pushbulletAccessToken", Required = Required.AllowNull)]
        public string PushbulletAccessToken { get; set; }

        [JsonProperty("test", Required = Required.AllowNull)]
        public string Test { get; set; }
    }
}
