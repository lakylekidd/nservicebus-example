using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class PaymentRefundedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public DateTime RefundDateTime { get; private set; }
        public double Amount { get; private set; }

        public PaymentRefundedEvent(Guid orderId, DateTime refundDateTime, double amount)
        {
            OrderId = orderId;
            RefundDateTime = refundDateTime;
            Amount = amount;
        }
    }
}
