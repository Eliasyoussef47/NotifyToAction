using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToActionConsole
{
    abstract class TcpConnector : IDisposable
    {
        public TcpConnector(IPAddress serverAddress, int serverPort)
        {
            ServerAddress = serverAddress;
            ServerPort = serverPort;
            Client = new TcpClient();
            Connect();
            Stream = Client.GetStream();
            Stream.ReadTimeout = 5000;
        }
        
        public TcpConnector(NetworkStream stream)
        {
            Stream = stream;
        }

        protected TcpClient Client;
        protected NetworkStream Stream;
        protected IPAddress ServerAddress;
        protected int ServerPort;

        public void Connect()
        {
            try
            {
                Client.Connect(ServerAddress, ServerPort);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public virtual void Dispose()
        {
            ((IDisposable)Client).Dispose();
            ((IDisposable)Stream).Dispose();
        }
    }
}
