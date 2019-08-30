using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Domain
{
    public class OrderAggregate: AggregateRootBase
    {
        public List<OrderItem> Items { get; private set; }
        public double TotalAmount { get; private set; }
        public int ItemCount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }

        private OrderAggregate()
        {
            // Generate order items
            Items = OrderItem.GenerateRandomOrderItems();
            calculateItemCount();
            calculateTotalAmount();
        }

        public void ChangeOrderStatus(OrderStatus status)
        {
            Status = status;
        }

        private void calculateTotalAmount()
        {
            TotalAmount = Items.Sum(x => x.Quantity * x.Price);
        }

        private void calculateItemCount()
        {
            ItemCount = Items.Sum(x => x.Quantity);
        }

        /// <summary>
        /// Create a new order with random order items
        /// </summary>
        /// <returns></returns>
        public static OrderAggregate Create() => new OrderAggregate();

    }
}
