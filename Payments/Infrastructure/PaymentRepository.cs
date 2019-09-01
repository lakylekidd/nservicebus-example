using Payments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Infrastructure
{
    public class PaymentRepository : IPaymentRepository
    {
        private List<PaymentAggregate> _payments = new List<PaymentAggregate>();

        public Task Create(PaymentAggregate payment)
        {
            return Task.Run(() => _payments.Add(payment));
        }

        public Task RefundPayment(Guid orderId)
        {
            return Task.Run(() => {
                var payment = _payments.Where(x => x.OrderId == orderId).FirstOrDefault();
                payment.RefundPayment();
            });
        }
    }
}
