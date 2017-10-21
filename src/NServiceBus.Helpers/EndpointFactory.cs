using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.Helpers
{
    public static class EndpointFactory
    {
        public static async Task<IEndpointInstance> Listen(string name)
        {
            var endpointConfiguration = new EndpointConfiguration(name);
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            transport.Routing().RouteToEndpoint(typeof(PlaceOrder), "Sales");
            transport.Routing().RouteToEndpoint(typeof(DoSomething), "ClientUI");
            transport.Routing().RouteToEndpoint(typeof(DoSomethingElse), "ClientUI");
            return await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }
    }
}
