using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class TcpConnector
    {
        public TcpConnector(IPAddress serverAddress, int serverPort)
        {
            ServerAddress = serverAddress;
            ServerPort = serverPort;
            Connect();
        }
        
        public TcpConnector(NetworkStream stream)
        {
            Stream = stream;
        }

        TcpClient Client;
        NetworkStream Stream;
        IPAddress ServerAddress;
        int ServerPort;

        public void Connect()
        {
            try
            {
                Client = new TcpClient();
                Client.Connect(ServerAddress, ServerPort);
                Stream = Client.GetStream();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public string SendMessage(string message)
        {
            using (StreamWriter sw = new StreamWriter(Stream))
            {
                sw.Write(message);
            }

            using (StreamReader sr = new StreamReader(Stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
