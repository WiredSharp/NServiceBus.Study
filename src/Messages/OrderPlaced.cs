using NServiceBus;
using System;

namespace Messages
{
    public class OrderPlaced: IEvent
    {
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrderPlaced)} #{OrderId}";
        }
    }
}
