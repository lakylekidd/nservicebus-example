using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Infrastructure
{
    public class PaymentRepository : IPaymentRepository
    {
        
        public Task ProcessPayment(Guid orderId, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
