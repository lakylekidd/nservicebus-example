using Notifications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Services
{
    public interface INotificationService
    {
        Task Send(Message message);
    }
}
