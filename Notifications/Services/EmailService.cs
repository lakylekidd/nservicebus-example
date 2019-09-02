using System.Threading.Tasks;
using Notifications.Domain;

namespace Notifications.Services
{
    public class EmailService : INotificationService
    {
        public Task Send(Message message)
        {
            // Simulate an e-mail send operation
            return Task.Delay(3000);
        }
    }
}
