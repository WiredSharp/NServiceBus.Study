using Messages;
using NServiceBus;
using NServiceBus.Helpers;
using NServiceBus.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Billing
{
    internal class Program
    {
        private static ILog Logger = LogManager.GetLogger("Billing");

        public static void Main(string[] args)
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            Console.Title = name;
            new Program().Run(name).Wait();
        }

        public async Task Run(string name)
        {
            IEndpointInstance endpoint = await EndpointFactory.Listen(name);
            //await endpoint.Subscribe(typeof(OrderPlaced));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);
        }
    }
}
