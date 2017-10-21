using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Billing.Handlers
{
    internal class OrderBilledHandler : IHandleMessages<OrderPlaced>
    {
        private ILog Logger = LogManager.GetLogger<OrderPlaced>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Logger.Info($"Received {message} notification");
            return context.Publish(new OrderBilled() { OrderId = message.OrderId });
        }
    }
}
