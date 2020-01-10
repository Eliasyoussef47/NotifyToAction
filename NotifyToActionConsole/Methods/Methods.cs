using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotifyToActionConsole
{
    class Methods
    {
        public Methods()
        {

        }

        //public void ShowMessageBox(string message)
        //{
        //    MessageBox.Show(message);
        //}

        public void Notify()
        {
            Debug.WriteLine("Notification received.");
        }
    }
}
