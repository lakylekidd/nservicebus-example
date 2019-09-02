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
            return Task.Run(() => {
                var order = _orders.Where(x => x.AggregateId == id).FirstOrDefault();
                order.ChangeOrderStatus(OrderStatus.Cancelled);
            });            
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
