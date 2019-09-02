using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class PaymentProcessedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public DateTime ProcessDateTime { get; private set; }
        public double Amount { get; private set; }

        public PaymentProcessedEvent(Guid orderId, DateTime processDateTime, double amount)
        {
            OrderId = orderId;
            ProcessDateTime = processDateTime;
            Amount = amount;
        }
    }
}
