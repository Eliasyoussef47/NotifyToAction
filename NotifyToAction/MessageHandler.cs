using Newtonsoft.Json;
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
    class MessageHandler
    {
        //TODO: make getting the ip address dynamic
        private static IPAddress ServerAddress = IPAddress.Parse("192.168.2.13");
        private static int ServerPort = 13000;
        public static TcpListener Server = new TcpListener(ServerAddress, ServerPort);

        public static async void Accept()
        {
            try
            {
                TcpClient client = await Server.AcceptTcpClientAsync();
                Debug.WriteLine("Connected!");
                //client.LingerState.Enabled = true;


                // Process the data sent by the client.
                JsonSerializer serializer = new JsonSerializer();
                RequestMessage requestMessage;

                using (NetworkStream stream = client.GetStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        requestMessage = serializer.Deserialize<RequestMessage>(reader);
                        requestMessage.RunMethod();

                        ResponseMessage responseMessage = new ResponseMessage {
                            Id = requestMessage.Id,
                            Result = MessageResult.OK
                        };
                        using (StreamWriter sw = new StreamWriter(stream))
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, responseMessage);
                        }
                    }
                }
                
                client.Close();
                Accept();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
