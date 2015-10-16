using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskReceiver.Backend;

namespace TaskReceiver.Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            Base myBase = new Base();
            myBase.Run();
            Console.WriteLine("Press enter to exit..");
            Console.ReadLine();
        }
    }

    class Base
    {
        public void Run()
        {
            TaskServServer server = new TaskServServer(7280);
            server.listen();
        }
    }
}
