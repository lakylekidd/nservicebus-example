using Core.Messages.Commands;
using Core.Messages.Events;
using NServiceBus;
using Orders.Domain;
using Orders.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Orders.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrderCommand>
    {
        IOrderRepository _orderRepository;
        static Random random = new Random();

        public PlaceOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(PlaceOrderCommand message, IMessageHandlerContext context)
        {
            #region ThrowTransientException
            // Uncomment to test throwing transient exceptions
            //if (random.Next(0, 5) == 0)
            //{
            //    throw new Exception("Oops");
            //}
            #endregion

            #region ThrowFatalException
            // Uncomment to test throwing fatal exceptions
            throw new Exception("BOOM");
            #endregion
            // Create a new random order
            var order = OrderAggregate.Create();
            // Save order in database
            await _orderRepository.Create(order);
            // Send the order placed event
            await context.Publish(new OrderPlacedEvent(order.AggregateId, order.ItemCount, order.TotalAmount));
        }
    }
}
