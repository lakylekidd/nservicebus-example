using System;

namespace Notifications.Domain
{
    public class Message
    {
        public DateTime MessageDateTimeSent { get; }
        public string Destination { get; }
        public string Content { get; }
        public MessageSendStatus Status { get; private set; }

        private Message(string content, string destination)
        {
            Content = content;
            Destination = destination;
            Status = MessageSendStatus.Created;
        }

        public void Success()
        {
            Status = MessageSendStatus.Sent;
        }

        public void Failed()
        {
            Status = MessageSendStatus.Failed;
        }

        public static Message Create(string content, string destination)
        {
            return new Message(content, destination);
        }
    }
}
