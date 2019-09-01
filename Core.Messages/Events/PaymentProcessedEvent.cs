using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class PaymentProcessedEvent : Event
    {
        public Guid OrderId { get; }
        public DateTime ProcessDateTime { get; }
        public double Amount { get; }

        public PaymentProcessedEvent(Guid orderId, DateTime processDateTime, double amount)
        {
            OrderId = orderId;
            ProcessDateTime = processDateTime;
            Amount = amount;
        }
    }
}
