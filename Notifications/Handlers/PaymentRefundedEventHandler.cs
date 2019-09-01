using Core.Messages.Events;
using Notifications.Domain;
using Notifications.Services;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Notifications.Handlers
{
    public class PaymentRefundedEventHandler : IHandleMessages<PaymentRefundedEvent>
    {
        private Func<NotificationType, INotificationService> _notificationServiceDelegate;

        public PaymentRefundedEventHandler(Func<NotificationType, INotificationService> notificationServiceDelegate)
        {
            _notificationServiceDelegate = notificationServiceDelegate;
        }

        public async Task Handle(PaymentRefundedEvent message, IMessageHandlerContext context)
        {
            // Invoke e - mail notification service
            INotificationService emailService = _notificationServiceDelegate(NotificationType.Email);
            // Create order placed message
            var emailMessage = Message.CreateAsEmail(
                "Order Refund!",
                "Your order has been refunded successfully. You will receive your money back to your account within a few days.",
                "client@email.com"
                );
            // Send the message
            await emailService.Send(emailMessage);
        }
    }
}
