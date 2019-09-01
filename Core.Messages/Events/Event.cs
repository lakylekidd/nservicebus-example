using NServiceBus;
using System;

namespace Core.Messages.Events
{
    public class Event : IEvent
    {
        public DateTime EventDateTime { get; }

        public Event()
        {
            EventDateTime = DateTime.Now;
        }
    }
}
