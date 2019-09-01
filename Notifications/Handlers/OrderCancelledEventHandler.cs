using Core.Messages.Events;
using Notifications.Domain;
using Notifications.Services;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Notifications.Handlers
{
    public class OrderCancelledEventHandler : IHandleMessages<OrderCancelledEvent>
    {
        private Func<NotificationType, INotificationService> _notificationServiceDelegate;

        public OrderCancelledEventHandler(Func<NotificationType, INotificationService> notificationServiceDelegate)
        {
            _notificationServiceDelegate = notificationServiceDelegate;
        }

        public async Task Handle(OrderCancelledEvent message, IMessageHandlerContext context)
        {
            // Invoke e - mail notification service
            INotificationService emailService = _notificationServiceDelegate(NotificationType.Email);
            // Create order placed message
            var emailMessage = Message.CreateAsEmail(
                "Order Cancelled!",
                "Your order has been cancelled! If that was an error, please contact customer support at support@mail.com.",
                "client@email.com"
                );
            // Send the message
            await emailService.Send(emailMessage);
        }
    }
}
