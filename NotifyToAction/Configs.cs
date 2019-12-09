using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    /// <summary>
    /// Represents the base object for configurations object. Will mainly contain a save method to save inhereting objects as json.
    /// </summary>
    class Configs
    {
        protected string FileName;

        public void Save()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            ConfigFile configFile = (ConfigFile)this;
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(FileName))
            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, configFile);
            }
        }

        public ConfigFile GetFile()
        {
            JsonSerializer serializer = new JsonSerializer();
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(FileName))
            using (StreamReader sw = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize<ConfigFile>(reader);
            }
        }
    }
}
