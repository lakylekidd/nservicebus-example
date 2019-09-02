using System;
using System.Threading.Tasks;
using Core.Messages.Events;
using Notifications.Domain;
using Notifications.Infrastructure;
using Notifications.Services;
using NServiceBus;

namespace Notifications.Handlers
{
    public class OrderPlacedEventHandler : IHandleMessages<OrderPlacedEvent>
    {
        private Func<NotificationType, INotificationService> _notificationServiceDelegate;
        private IMessageRepository _messageRepository;

        public OrderPlacedEventHandler(Func<NotificationType, INotificationService> notificationServiceDelegate, IMessageRepository messageRepository)
        {
            _notificationServiceDelegate = notificationServiceDelegate;
            _messageRepository = messageRepository;
        }

        public async Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            // Invoke e-mail notification service
            INotificationService emailService = _notificationServiceDelegate(NotificationType.Email);
            // Create order placed message
            var emailMessage = Message.CreateAsEmail(
                "Order " + message.OrderId + " placed successfully!",
                "Your order has been received successfully. You will receive another e-mail once your payment has been processed.",
                "client@email.com"
                );
            // Save message
            await _messageRepository.Create(emailMessage);
            // Send the message
            await emailService.Send(emailMessage);
        }
    }
}
