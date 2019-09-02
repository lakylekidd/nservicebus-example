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

        public Task<PaymentAggregate> GetByOrderId(Guid orderId)
        {
            return Task.Run(() => {
                return _payments.Where(x => x.OrderId == orderId).FirstOrDefault();
            });
        }

        public Task Create(PaymentAggregate payment)
        {
            return Task.Run(() => _payments.Add(payment));
        }

        public Task<List<PaymentAggregate>> GetAll()
        {
            return Task.Run(() => _payments.ToList());
        }
    }
}
