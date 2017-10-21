using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.Handlers
{
    class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private ILog Logger = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            Logger.Info($"Received {message}");
            return Task.CompletedTask;
        }
    }
}
