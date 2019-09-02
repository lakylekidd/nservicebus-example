using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class OrderCancelledEvent : Event
    {
        public Guid OrderId { get; private set; }
        public DateTime CancellationDateTime { get; private set; }

        public OrderCancelledEvent(Guid id, DateTime cancellationDateTime)
        {
            OrderId = id;
            CancellationDateTime = cancellationDateTime;
        }
    }
}
