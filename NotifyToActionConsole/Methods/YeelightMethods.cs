using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToActionConsole
{
    class YeelightMethods : TcpSender
    {
        public YeelightMethods(IPAddress serverAddress, int serverPort) : base(serverAddress, serverPort)
        {

        }

        public YeelightMethods() : base(IPAddress.Parse("192.168.2.15"), 55443)
        {
            
        }

        public void Toggle()
        {
            string message = "{\"id\":1,\"method\":\"toggle\",\"params\":[]}";
            SendMessage(message);
        }

        public void Default()
        {
            string[] messages = new string[2];
            messages[0] = "{\"id\":1,\"method\":\"set_bright\",\"params\":[50, \"smooth\", 200]}";
            messages[1] = "{\"id\":1,\"method\":\"set_ct_abx\",\"params\":[4091, \"smooth\", 200]}";
            SendMessage(messages);
        }

        public void TurnOn()
        {
            string message = "{\"id\":1,\"method\":\"set_power\",\"params\":[\"on\", \"smooth\", 500]}";
            SendMessage(message);
        }

        public void Bright()
        {
            string message = "{\"id\":1,\"method\":\"set_bright\",\"params\":[100, \"sudden\", 30]}";
            SendMessage(message);
        }

        public void Blue()
        {
            string message = "{\"id\":1,\"method\":\"set_rgb\",\"params\":[255, \"sudden\", 30]}";
            SendMessage(message);
        }

        public void Red()
        {
            string message = "{\"id\":1,\"method\":\"set_rgb\",\"params\":[16711682, \"sudden\", 30]}";
            SendMessage(message);
        }

        public void Notify()
        {
            TurnOn();
            Bright();
            Task.Delay(200).ContinueWith(t => Blue());
            Task.Delay(400).ContinueWith(t => Red());
            Task.Delay(600).ContinueWith(t => Blue());
            Task.Delay(800).ContinueWith(t => Red());
            Task.Delay(1000).ContinueWith(t => Default());
            Task.Delay(1200).ContinueWith(t => Dispose());
        }
    }
}
