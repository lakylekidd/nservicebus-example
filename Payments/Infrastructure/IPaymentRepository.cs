using System;
using System.Threading.Tasks;

namespace Payments.Infrastructure
{
    public interface IPaymentRepository
    {
        Task ProcessPayment(Guid orderId, double amount);
    }
}
