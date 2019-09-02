using Notifications.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Infrastructure
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAll();
        Task Create(Message message);
    }
}
