using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
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
            string FilePath = Path.Combine(AssemblyFolderPath, fileName);
            return File.Open(FilePath, FileMode.OpenOrCreate);
        }
    }
}