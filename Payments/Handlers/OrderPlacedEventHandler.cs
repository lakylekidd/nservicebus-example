using System.Threading.Tasks;
using Core.Messages.Events;
using NServiceBus;
using Payments.Infrastructure;

namespace Payments.Handlers
{
    public class OrderPlacedEventHandler : IHandleMessages<OrderPlacedEvent>
    {
        IPaymentRepository _paymentRepository;

        public OrderPlacedEventHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
