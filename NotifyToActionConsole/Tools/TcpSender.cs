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
    class TcpSender : TcpConnector, IDisposable
    {
        public TcpSender(IPAddress serverAddress, int serverPort) : base(serverAddress, serverPort)
        {
            StreamWriter = new StreamWriter(Stream);
            StreamReader = new StreamReader(Stream);
        }

        public StreamWriter StreamWriter;
        public StreamReader StreamReader;

        public void SendMessage(string message)
        {
            StreamWriter.WriteLine(message);
            StreamWriter.Flush();
            //while (StreamReader.Peek() != -1)
            //{
            //    string streamLine = StreamReader.ReadLine();
            //    Debug.WriteLine("Response: " + streamLine);
            //};
            StreamReader.DiscardBufferedData();
        }

        public void SendMessage(string[] messages)
        {
            foreach (string message in messages)
            {
                SendMessage(message);
            }
        }

        public override void Dispose()
        {
            ((IDisposable)Client).Dispose();
            ((IDisposable)Stream).Dispose();
            ((IDisposable)StreamWriter).Dispose();
            ((IDisposable)StreamReader).Dispose();
        }
    }
}
