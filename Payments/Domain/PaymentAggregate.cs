using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Domain
{
    public class PaymentAggregate : AggregateRootBase
    {
        public Guid OrderId { get; }
        public DateTime PaymentDateTime { get; }
        public double Amount { get; }
        public PaymentStatus Status { get; private set; }

        private PaymentAggregate(Guid orderId, double amount)
        {
            OrderId = orderId;
            Amount = amount;
            PaymentDateTime = DateTime.Now;
            Status = PaymentStatus.Created;
        }

        public void ProcessPayment()
        {
            Status = PaymentStatus.Processed;
        }

        public void RefundPayment()
        {
            Status = PaymentStatus.Refunded;
        }

        public static PaymentAggregate Create(Guid orderId, double amount)
        {
            return new PaymentAggregate(orderId, amount);
        }
    }
}
