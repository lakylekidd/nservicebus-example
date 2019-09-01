using Orders.Domain;
using System;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public interface IOrderRepository
    {
        Task Create(OrderAggregate order);
        Task CancelOrder(Guid id);
    }
}
