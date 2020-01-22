using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotifyToAction
{
    public class Message
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Include, Order = 0)]
        public int Id;
    }

    enum MessageResult { OK, ERROR }
}
