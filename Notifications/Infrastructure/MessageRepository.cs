using Notifications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        private List<Message> _messages = new List<Message>();

        public Task Create(Message message)
        {
            return Task.Run(() => _messages.Add(message));
        }

        public Task<List<Message>> GetAll()
        {
            return Task.Run(() =>
            {
                return _messages.ToList();
            });
        }
    }
}
