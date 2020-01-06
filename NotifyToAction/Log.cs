using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    public class Log
    {
        public Log(DirectoryPathIds DirectoryPathId = DirectoryPathIds.CurrentDirectory1, string LogFileName = null)
        {
            if (DirectoryPathId == DirectoryPathIds.CurrentDirectory1)
            {
                DirectoryPath = Directory.GetCurrentDirectory();
            }
            else if (DirectoryPathId == DirectoryPathIds.CurrentDirectory2)
            {
                DirectoryPath = Environment.CurrentDirectory;
            }
            else if (DirectoryPathId == DirectoryPathIds.Desktop)
            {
                DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else if (DirectoryPathId == DirectoryPathIds.AppDataFolder)
            {
                LocalAppDataFolder localAppDataFolder = new LocalAppDataFolder();
                DirectoryPath = localAppDataFolder.AssemblyFolderPath;
            }

            if (LogFileName == null)
            {
                LogFileName = "LOG" + GetTimeStamp().ToString();
            }

            LogFullFileName = LogFileName + ".txt";
            FullFilePath = DirectoryPath + @"\" + LogFullFileName;
            try
            {
                if (File.Exists(FullFilePath))
                {
                    LogFileName += "(" + FileCount++.ToString() + ")";
                    LogFullFileName = LogFileName + ".txt";
                    FullFilePath = DirectoryPath + @"\" + LogFullFileName;
                }

                using (FileStream fs = File.Create(FullFilePath))
                {
                    Console.WriteLine("file created. Name: " + LogFullFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string FullFilePath;
        private string LogFullFileName;
        private string LogFileName;
        private string DirectoryPath;
        private static int FileCount = 1;

        public void WriteLine(string text, bool withTimeStamp = false)
        {
            using (StreamWriter File = new StreamWriter(FullFilePath, true))
            {
                if (withTimeStamp)
                {
                    File.WriteLine(text + " @ " + DateTime.Now);
                } else
                {
                    File.WriteLine(text);
                }
                
            }
        }

        public void WriteDivider()
        {
            using (StreamWriter File = new StreamWriter(FullFilePath, true))
            {
                File.WriteLine("---------------------------------------------");
            }
        }

        public void LogMethodInfo(LogMethodInfo logMethodInfo, MethodBase methodBase)
        {
            if (logMethodInfo == NotifyToAction.LogMethodInfo.Start)
            {
                WriteLine(methodBase.DeclaringType.Name + "." + methodBase.Name + " started", true);
            } else if (logMethodInfo == NotifyToAction.LogMethodInfo.End)
            {
                WriteLine(methodBase.DeclaringType.Name + "." + methodBase.Name + " ended", true);
            }
        }

        //public void LogMethodArgs(MethodBase methodBase, List<dynamic> args)
        //{
        //    WriteLine(methodBase.DeclaringType.Name + "." + methodBase.Name + " arguments:");
        //    foreach (dynamic arg in args)
        //    foreach (ParameterInfo parameterInfo in methodBase.GetParameters())
        //    {
        //        WriteLine(parameterInfo.Name + ": " + arg.ToString());
        //    }
        //}

        private int GetTimeStamp()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }

    public enum DirectoryPathIds
    {
        CurrentDirectory1 = 1,
        CurrentDirectory2 = 2,
        Desktop = 3,
        AppDataFolder = 4
    }

    public enum LogMethodInfo
    {
        Start,
        End
    }
}
