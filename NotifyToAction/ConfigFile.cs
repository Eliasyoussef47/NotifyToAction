using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class ConfigFile : Configs
    {
        public ConfigFile()
        {
            FileName = "Configs.json";
            GetFile();
        }

        public ConfigFile(string fileName)
        {
            FileName = fileName;
            GetFile();
        }

        [JsonProperty("test",  Required = Required.AllowNull)]
        public string Test;
    }
}
