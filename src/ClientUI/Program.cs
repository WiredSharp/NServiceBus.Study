using Messages;
using NServiceBus;
using NServiceBus.Helpers;
using NServiceBus.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ClientUI
{
    internal class Program
    {
        private static ILog Logger = LogManager.GetLogger("ClientUI");

        public static void Main(string[] args)
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            Console.Title = name;
            new Program().Run(name).Wait();
        }

        public async Task Run(string name)
        {
            IEndpointInstance endpoint = await EndpointFactory.Listen(name);
            await PlaceOrderLoop(endpoint);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);
        }

        private async Task PlaceOrderLoop(IEndpointInstance endpoint)
        {
            bool stop = false;
            do
            {
                Console.WriteLine("(P)lace order, (Q)uit?");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case 'P':
                    case 'p':
                        PlaceOrder placeOrder = new PlaceOrder() { OrderId = Guid.NewGuid().ToString() };
                        Logger.Info($"sending {placeOrder}");
                        await endpoint.Send(placeOrder).ConfigureAwait(false);
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

        private async Task PlaceLocalOrderLoop(IEndpointInstance endpoint)
        {
            bool stop = false;
            do
            {
                Console.WriteLine("(P)lace order, (Q)uit?");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case 'P':
                    case 'p':
                        PlaceOrder placeOrder = new PlaceOrder() { OrderId = Guid.NewGuid().ToString() };
                        Logger.Info($"sending {placeOrder}");
                        await endpoint.SendLocal(placeOrder).ConfigureAwait(false);
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
