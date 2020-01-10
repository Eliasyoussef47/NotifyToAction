using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NotifyToActionConsole
{
    abstract class ConfigsTools //the base class that just contains methods to safe and retrieve the file
    {
        public void Save()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            var configFile = this;
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();//an object with a method that return a stream to the AppData/local project folder where I save the config file
            FieldInfo fieldInfo = this.GetType().GetField("ConfigsFileName", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            string value = (string)fieldInfo.GetValue(null);
            using (FileStream stream = localAppDataFolder.GetFile(value))
            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, configFile);
            }
        }

        public static T GetConfigs<T>() where T : ConfigsTools, new()
        {
            T result;
            JsonSerializer serializer = new JsonSerializer();
            FieldInfo fieldInfo = typeof(T).GetField("ConfigsFileName", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            string value = (string)fieldInfo.GetValue(null);
            LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
            using (FileStream stream = localAppDataFolder.GetFile(value))
            using (StreamReader sw = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                result = serializer.Deserialize<T>(reader);
            }
            if (result == null)
            {
                result = new T();
            }
            return result;
        }
    }

    public class LocalAppDataFolder //a class that lets me save the configs file in the local AppData
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
