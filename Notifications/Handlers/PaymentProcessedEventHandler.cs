using Core.Messages.Events;
using Notifications.Domain;
using Notifications.Services;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Notifications.Handlers
{
    public class PaymentProcessedEventHandler : IHandleMessages<PaymentProcessedEvent>
    {
        private Func<NotificationType, INotificationService> _notificationServiceDelegate;

        public PaymentProcessedEventHandler(Func<NotificationType, INotificationService> notificationServiceDelegate)
        {
            _notificationServiceDelegate = notificationServiceDelegate;
        }

        public async Task Handle(PaymentProcessedEvent message, IMessageHandlerContext context)
        {
            // Invoke e - mail notification service
            INotificationService emailService = _notificationServiceDelegate(NotificationType.Email);
            // Create order placed message
            var emailMessage = Message.CreateAsEmail(
                "Payment Completed successfully!",
                "Your payment has been processed successfully!",
                "client@email.com"
                );
            // Send the message
            await emailService.Send(emailMessage);
        }
    }
}
