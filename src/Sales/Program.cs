using Messages;
using NServiceBus;
using NServiceBus.Helpers;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    internal class Program
    {
        private static ILog Logger = LogManager.GetLogger("Sales");

        public static void Main(string[] args)
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            Console.Title = name;
            new Program().Run(name).Wait();
        }

        public async Task Run(string name)
        {
            IEndpointInstance endpoint = await EndpointFactory.Listen(name);
            await DoSomethingLoop(endpoint);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);
        }


        private async Task DoSomethingLoop(IEndpointInstance endpoint)
        {
            bool stop = false;
            do
            {
                Console.WriteLine("(D)o something, (Q)uit?");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case 'D':
                    case 'd':
                        DoSomething command = new DoSomething() { SomeProperty = Guid.NewGuid().ToString() };
                        Logger.Info($"sending {command}");
                        await endpoint.Send(command).ConfigureAwait(false);
                        break;
                    case 'Q':
                    case 'q':
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("What?");
                        break;
                }
            }
            while (!stop);
        }
    }
}
