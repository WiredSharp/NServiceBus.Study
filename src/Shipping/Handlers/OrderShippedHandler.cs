using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Shipping.Handlers
{
    internal class OrderShippedHandler : IHandleMessages<OrderBilled>
    {
        private ILog Logger = LogManager.GetLogger<OrderPlaced>();

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            Logger.Info($"Received {message} notification");
            return context.Publish(new OrderShipped() { OrderId = message.OrderId });
        }
    }
}
