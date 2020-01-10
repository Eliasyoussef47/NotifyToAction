using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NotifyToActionConsole
{
    class ResponseMessage : Message
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore, Order = 1, Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResult Result;
    }
}
