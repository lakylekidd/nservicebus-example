using Core.Messages.Commands;
using Core.Messages.Events;
using NServiceBus;
using Orders.Domain;
using Orders.Infrastructure;
using System.Threading.Tasks;

namespace Orders.Handlers
{
    public class CancelOrderHandler : IHandleMessages<CancelOrderCommand>
    {
        IOrderRepository _orderRepository;

        public CancelOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CancelOrderCommand message, IMessageHandlerContext context)
        {
            // Save order in database
            await _orderRepository.CancelOrder(message.OrderId);
            // Send the order placed event
            await context.Publish(new OrderCancelledEvent(message.OrderId, message.OrderCancellationDateTime));
        }
    }
}
