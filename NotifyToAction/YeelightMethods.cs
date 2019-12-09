using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class YeelightMethods : TcpSender
    {
        public static string Toggle(NetworkStream stream)
        {
            string message = "{\"id\":1,\"method\":\"toggle\",\"params\":[]}";
            return SendMessage(stream, message);
        }
    }
}
