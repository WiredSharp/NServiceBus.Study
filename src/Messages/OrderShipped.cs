using NServiceBus;
using System;

namespace Messages
{
    public class OrderShipped : IEvent
    {
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrderShipped)} #{OrderId}";
        }
    }
}
