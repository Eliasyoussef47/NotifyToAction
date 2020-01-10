using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToActionConsole
{
    static class MessageMethods
    {
        public static void Trigger(string senderId, string triggerId)
        {
            Configs configs = ConfigsTools.GetConfigs<Configs>();
            RegisteredTrigger registeredTrigger = configs.GetRegisteredTrigger(senderId, triggerId);
            if (registeredTrigger != null)
            {
                foreach (RegisteredTriggerAction action in registeredTrigger.Actions)
                {
                    Type theType = System.Reflection.Assembly.GetExecutingAssembly().GetType("NotifyToActionConsole." + action.TypeName);
                    var theInstance = Activator.CreateInstance(theType);
                    MethodInfo theMethod = theType.GetMethod(action.MethodName);
                    if (action.MethodParameters == null)
                    {
                        theMethod.Invoke(theInstance, null);
                    }
                    else
                    {
                        theMethod.Invoke(theInstance, action.MethodParameters.ToArray());
                    }
                }
            }
        }

        public static void Test(string a, string b)
        {
            Debug.WriteLine("First parameter: {0}. Second parameter: {1}", a, b);
        }
    }
}
