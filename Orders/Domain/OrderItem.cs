using System;
using System.Collections.Generic;
using System.Linq;

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
            Id = Guid.NewGuid();
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        protected OrderItem()
        {

        }

        private static OrderItem Create(string description, double price, int quantity)
        {
            return new OrderItem(description, price, quantity);
        }

        #region random generation
        private static Dictionary<string, double> _itemsAndPricesDictionary = new Dictionary<string, double>()
        {
            { "Tent Size:M", 29.99 },
            { "Tent Size:L", 149.99 },
            { "Backpack 1", 34.99 },
            { "Backpack 2", 46.00 },
            { "Flashlight", 12.00 },
            { "Swiss Army", 24.00 },
            { "Diving Mask", 6.00 },
            { "Flippers Size 5-6", 14.00 },
            { "Flippers Size 7-8", 15.00 },
            { "Flippers Size 9-10", 16.00 },
            { "Sun Block SPF 30", 12.00 },
            { "Sun Block SPF 40", 12.00 },
            { "Sun Block SPF 50", 12.00 },
            { "Sun Block SPF 60", 12.00 },
        };

        private static int getRandomNumber(int max, bool allowZero = false)
        {
            Random rnd = new Random();
            int num = rnd.Next(max);
            if (!allowZero && num == 0) return 1;
            return num;
        }

        /// <summary>
        /// Create a new random list of order items
        /// </summary>
        /// <returns></returns>
        public static List<OrderItem> GenerateRandomOrderItems()
        {
            // List that holds the order items
            List<OrderItem> items = new List<OrderItem>();
            // Determine how many items the order should hold
            int orderItemCount = OrderItem.getRandomNumber(6);
            // For each item get a random item from the list
            for (int i = 0; i < orderItemCount; i++)
            {
                // Generate random index number for dictionary
                int index = getRandomNumber(_itemsAndPricesDictionary.Count - 1, true);
                // Get the item from the dictionary index
                var itemKeyValuePair = OrderItem._itemsAndPricesDictionary.ElementAt(index);
                var item = OrderItem.Create(itemKeyValuePair.Key, itemKeyValuePair.Value, getRandomNumber(3));
                // Add item to the list
                items.Add(item);
            }
            // Return the items
            return items;
        }
        #endregion
    }
}
