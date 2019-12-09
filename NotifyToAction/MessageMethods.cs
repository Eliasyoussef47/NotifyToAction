using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    static class MessageMethods
    {
        public static void Trigger()
        {

        }

        

        public static void Test(string a, string b)
        {
            Debug.WriteLine("First parameter: {0}. Second parameter: {1}", a, b);
        }
    }
}
