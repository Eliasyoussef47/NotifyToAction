using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class RegisteredTrigger
    {
        [JsonProperty("triggerId", Required = Required.AllowNull)]
        public string TriggerId;
    }
}
