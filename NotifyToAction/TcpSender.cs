using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class TcpSender
    {
        public static string SendMessage(NetworkStream stream, string message)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write(message);
            }

            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
