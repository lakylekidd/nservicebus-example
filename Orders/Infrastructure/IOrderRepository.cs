using Orders.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public interface IOrderRepository
    {
        Task<List<OrderAggregate>> GetAll();
        Task Create(OrderAggregate order);
        Task CancelOrder(Guid id);
    }
}
