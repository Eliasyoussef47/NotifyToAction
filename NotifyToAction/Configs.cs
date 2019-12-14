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
        }

        public Configs(string fileName)
        {
            ConfigsFileName = fileName;
        }

        [JsonProperty("registeredSenderTriggers")]
        public List<RegisteredSenderTriggers> RegisteredSenderTriggers;

        [JsonProperty("test", Required = Required.AllowNull)]
        public string Test;
    }

    /// <summary>
    /// Represents the base object for configurations object. Will mainly contain a save method to save inhereting objects as json.
    /// </summary>
    class ConfigsTools
    {
        protected string ConfigsFileName;

        public void Save<T>()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            var configFile = this;
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(ConfigsFileName))
            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, configFile);
            }
        }

        protected T GetFile<T>()
        {
            JsonSerializer serializer = new JsonSerializer();
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(ConfigsFileName))
            using (StreamReader sw = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize<T>(reader);
            }
        }
    }

    public class LocalAppDataFolder
    {
        public LocalAppDataFolder(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        public LocalAppDataFolder()
        {
            AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        private static readonly string LocalAppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string AssemblyName;
        public string AssemblyFolderPath
        {
            get
            {
                string FolderPath = Path.Combine(LocalAppDataFolderPath, AssemblyName);
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                return FolderPath;
            }
        }

        public FileStream GetFile(string fileName)
        {
            string filePath = Path.Combine(AssemblyFolderPath, fileName);
            return File.Open(filePath, FileMode.OpenOrCreate);
        }
    }
}
