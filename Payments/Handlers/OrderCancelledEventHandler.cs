using System;
using System.Threading.Tasks;
using Core.Messages.Events;
using NServiceBus;
using Payments.Infrastructure;

namespace Payments.Handlers
{
    public class OrderCancelledEventHandler : IHandleMessages<OrderCancelledEvent>
    {
        IPaymentRepository _paymentRepository;

        public OrderCancelledEventHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task Handle(OrderCancelledEvent message, IMessageHandlerContext context)
        {
            var payment = await _paymentRepository.GetByOrderId(message.OrderId);
            payment.RefundPayment();
            await context.Publish(new PaymentRefundedEvent(payment.OrderId, DateTime.Now, payment.Amount));
        }
    }
}
