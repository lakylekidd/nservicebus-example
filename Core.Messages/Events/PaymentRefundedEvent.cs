using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Messages.Events
{
    public class PaymentRefundedEvent : Event
    {
        public Guid OrderId { get; }
        public DateTime RefundDateTime { get; }
        public double Amount { get; }

        public PaymentRefundedEvent(Guid orderId, DateTime refundDateTime, double amount)
        {
            OrderId = orderId;
            RefundDateTime = refundDateTime;
            Amount = amount;
        }
    }
}
