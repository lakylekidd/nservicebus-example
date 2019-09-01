using Payments.Domain;
using System;
using System.Threading.Tasks;

namespace Payments.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Create(PaymentAggregate payment);
        Task<PaymentAggregate> GetByOrderId(Guid orderId);
    }
}
