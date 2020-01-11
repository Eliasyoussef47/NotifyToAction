using System;

namespace NotifyToActionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MessageHandler.Accept();
            while (true)
            {
                Console.ReadKey();
            };
        }
    }
}
