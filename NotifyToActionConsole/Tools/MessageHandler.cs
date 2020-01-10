using Newtonsoft.Json;
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
    class MessageHandler
    {
        //TODO: make getting the ip address dynamic
        //private static IPAddress ServerAddress = IPAddress.Parse("192.168.2.13");
        private static int ServerPort = 13000;
        //public static TcpListener Server = new TcpListener(ServerAddress, ServerPort);
        public static UdpClient UdpClient = new UdpClient(ServerPort);

        public static async void Accept()
        {
            try
            {
                UdpReceiveResult receiveResult = await UdpClient.ReceiveAsync();

                string received = Encoding.ASCII.GetString(receiveResult.Buffer, 0, receiveResult.Buffer.Length);
                
                JsonSerializer serializer = new JsonSerializer();

                using (StringReader sr = new StringReader(received))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    RequestMessage requestMessage = serializer.Deserialize<RequestMessage>(reader);
                    requestMessage.RunMethod();

                    //ResponseMessage responseMessage = new ResponseMessage
                    //{
                    //    Id = requestMessage.Id,
                    //    Result = MessageResult.OK
                    //};
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //using (JsonWriter writer = new JsonTextWriter(sw))
                    //{
                    //    serializer.Serialize(writer, responseMessage);
                    //}
                }

                //client.Close();
                Accept();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
