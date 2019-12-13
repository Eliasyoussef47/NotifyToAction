using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class Configs : ConfigsTools
    {
        public Configs()
        {
            ConfigsFileName = "Configs.json";
            GetFile();
        }

        public Configs(string fileName)
        {
            ConfigsFileName = fileName;
            GetFile();
        }

        [JsonProperty("test", Required = Required.AllowNull)]
        public string Test;
    }

    /// <summary>
    /// Represents the base object for configurations object. Will mainly contain a save method to save inhereting objects as json.
    /// </summary>
    class ConfigsTools
    {
        protected string ConfigsFileName;

        public void Save()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            Configs configFile = (Configs)this;
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(ConfigsFileName))
            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, configFile);
            }
        }

        public Configs GetFile()
        {
            JsonSerializer serializer = new JsonSerializer();
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(ConfigsFileName))
            using (StreamReader sw = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize<Configs>(reader);
            }
        }
    }
}
