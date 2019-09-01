using Core.Messages.Commands;
using Core.Messages.Events;
using NServiceBus;
using Orders.Domain;
using Orders.Infrastructure;
using System.Threading.Tasks;

namespace Orders.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrderCommand>
    {
        IOrderRepository _orderRepository;

        public PlaceOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(PlaceOrderCommand message, IMessageHandlerContext context)
        {
            // Create a new random order
            var order = OrderAggregate.Create();
            // Save order in database
            await _orderRepository.Create(order);
            // Send the order placed event
            await context.Publish(new OrderPlacedEvent(order.AggregateId, order.ItemCount, order.TotalAmount));
        }
    }
}
