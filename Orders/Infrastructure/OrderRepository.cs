using Orders.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public class OrderRepository: IOrderRepository
    {
        private List<OrderAggregate> _orders = new List<OrderAggregate>();

        public Task Create(OrderAggregate order)
        {
            return Task.Run(() => _orders.Add(order));
        }
    }
}
