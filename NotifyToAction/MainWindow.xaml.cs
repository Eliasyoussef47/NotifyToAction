using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotifyToAction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //public static Log MyLog = new Log(DirectoryPathIds.AppDataFolder);

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Configs configs = ConfigsTools.GetConfigs<Configs>();
            //configs.Test = "YOYO";
            //RegisteredTrigger registeredTrigger = new RegisteredTrigger();
            //registeredTrigger.TriggerId = "DoorOpened";
            //RegisteredTriggerAction action = new RegisteredTriggerAction("YeelightMethods", "Toggle", null);
            //registeredTrigger.Actions.Add(action);
            //RegisteredSenderTriggers registeredSenderTriggers = new RegisteredSenderTriggers();
            //registeredSenderTriggers.SenderId = "DoorSensor";
            //List<RegisteredTrigger> registeredTriggers = new List<RegisteredTrigger>();
            //registeredTriggers.Add(registeredTrigger);
            //registeredSenderTriggers.RegisteredTriggers = registeredTriggers;
            //configs.RegisteredSenderTriggers.Add(registeredSenderTriggers);
            //configs.YeelightLampIp = "192.168.2.15";
            //configs.Save();
            
            MessageHandler.Accept();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageHandler.UdpClient.Dispose();
        }
    }
}
