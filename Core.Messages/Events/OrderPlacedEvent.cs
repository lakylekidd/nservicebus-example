using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class OrderPlacedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public int Items { get; private set; }
        public double Amount { get; private set; }

        public OrderPlacedEvent(Guid id, int items, double amount)
        {
            OrderId = id;
            Items = items;
            Amount = amount;
        }
    }
}
