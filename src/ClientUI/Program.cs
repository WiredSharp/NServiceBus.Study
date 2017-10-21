using Messages;
using NServiceBus;
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
            new Program().Run(args).Wait();
        }

        public async Task Run(string[] args)
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            Console.Title = name;
            var endpointConfiguration = new EndpointConfiguration(name);
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            IEndpointInstance endpoint = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            await RunLocal(endpoint);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);
        }

        private async Task RunLocal(IEndpointInstance endpoint)
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
