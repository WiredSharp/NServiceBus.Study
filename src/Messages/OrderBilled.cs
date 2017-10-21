using NServiceBus;
using System;

namespace Messages
{
    public class OrderBilled : IEvent
    {
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrderBilled)} #{OrderId}";
        }
    }
}
