using System;
using System.Threading.Tasks;
using Notifications.Domain;

namespace Notifications.Services
{
    public class SMSService : INotificationService
    {
        public Task Send(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
