using System;

namespace Orders.Domain
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }

        private OrderItem(string description, double price, int quantity)
        {

        }

        protected OrderItem()
        {

        }

        /// <summary>
        /// Create a new random item
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItem Create(string description, double price, int quantity = 1)
        {
            return new OrderItem(description, price, quantity);
        }

        #region random generation

        #endregion
    }
}
