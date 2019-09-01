using System;
using System.Threading.Tasks;
using Core.Messages.Events;
using NServiceBus;
using Payments.Domain;
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

        public async Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            var payment = PaymentAggregate.Create(message.OrderId, message.Amount);
            payment.ProcessPayment();
            await _paymentRepository.Create(payment);
            await context.Publish(new PaymentProcessedEvent(payment.OrderId, DateTime.Now, payment.Amount));
        }
    }
}
