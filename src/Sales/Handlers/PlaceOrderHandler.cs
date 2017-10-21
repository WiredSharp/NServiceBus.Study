using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Sales.Handlers
{
    class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private ILog Logger = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            Logger.Info($"Received {message}");
            return context.Publish(new OrderPlaced() { OrderId = message.OrderId });
        }
    }
}
