using System.Threading.Tasks;
using Core.Messages.Events;
using NServiceBus;

namespace Payments.Handlers
{
    public class OrderPlacedEventHandler : IHandleMessages<OrderPlacedEvent>
    {
        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
