using Core;
using System.Collections.Generic;

namespace Orders.Domain
{
    public class OrderAggregate: AggregateRootBase
    {
        public List<OrderItem> Items { get; private set; }
        public double TotalAmount { get; }
        public int ItemCount { get; }
    }
}
