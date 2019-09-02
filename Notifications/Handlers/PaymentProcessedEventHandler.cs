using Core.Messages.Events;
using Notifications.Domain;
using Notifications.Infrastructure;
using Notifications.Services;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Notifications.Handlers
{
    public class PaymentProcessedEventHandler : IHandleMessages<PaymentProcessedEvent>
    {
        private Func<NotificationType, INotificationService> _notificationServiceDelegate;
        private IMessageRepository _messageRepository;

        public PaymentProcessedEventHandler(Func<NotificationType, INotificationService> notificationServiceDelegate, IMessageRepository messageRepository)
        {
            _notificationServiceDelegate = notificationServiceDelegate;
            _messageRepository = messageRepository;
        }

        public async Task Handle(PaymentProcessedEvent message, IMessageHandlerContext context)
        {
            // Invoke e - mail notification service
            INotificationService emailService = _notificationServiceDelegate(NotificationType.Email);
            // Create order placed message
            var emailMessage = Message.CreateAsEmail(
                "Payment for " + message.OrderId + " Completed successfully!",
                "Your payment has been processed successfully!",
                "client@email.com"
                );
            // Save message
            await _messageRepository.Create(emailMessage);
            // Send the message
            await emailService.Send(emailMessage);
        }
    }
}
