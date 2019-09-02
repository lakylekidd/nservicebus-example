using Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public class OrderRepository: IOrderRepository
    {
        private List<OrderAggregate> _orders = new List<OrderAggregate>();

        public Task CancelOrder(Guid id)
        {
            var order = _orders.FirstOrDefault(x => x.AggregateId == id);
            if (order != null) order.ChangeOrderStatus(OrderStatus.Cancelled);

            return Task.FromResult(0);          
        }

        public Task Create(OrderAggregate order)
        {
            return Task.Run(() => _orders.Add(order));
        }

        public Task<List<OrderAggregate>> GetAll()
        {
            return Task.Run(() =>
            {
                return _orders.ToList();
            });
        }
    }
}
