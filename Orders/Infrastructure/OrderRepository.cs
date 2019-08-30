using Orders.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public class OrderRepository: IOrderRepository
    {
        private List<OrderAggregate> _orders = new List<OrderAggregate>();

        public async void Create(OrderAggregate order)
        {
            await Task.Run(() => _orders.Add(order));
        }
    }
}
