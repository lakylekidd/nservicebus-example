using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class OrderPlacedEvent : Event
    {
        public Guid OrderId { get; }
        public int Items { get; }
        public double Amount { get; }

        public OrderPlacedEvent(Guid id, int items, double amount)
        {
            OrderId = id;
            Items = items;
            Amount = amount;
        }
    }
}
