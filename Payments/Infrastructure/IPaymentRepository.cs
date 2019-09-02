using Payments.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Infrastructure
{
    public interface IPaymentRepository
    {
        Task<List<PaymentAggregate>> GetAll();
        Task Create(PaymentAggregate payment);
        Task<PaymentAggregate> GetByOrderId(Guid orderId);
    }
}
