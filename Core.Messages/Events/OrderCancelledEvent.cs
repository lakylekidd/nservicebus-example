using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class OrderCancelledEvent : Event
    {
        public Guid OrderId { get; }
        public DateTime CancellationDateTime { get; }

        public OrderCancelledEvent(Guid id, DateTime cancellationDateTime)
        {
            OrderId = id;
            CancellationDateTime = cancellationDateTime;
        }
    }
}
