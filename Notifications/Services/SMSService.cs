using System.Threading.Tasks;
using Notifications.Domain;

namespace Notifications.Services
{
    public class SMSService : INotificationService
    {
        public Task Send(Message message)
        {
            // Simulate an SMS send operation
            return Task.Delay(3000);
        }
    }
}
