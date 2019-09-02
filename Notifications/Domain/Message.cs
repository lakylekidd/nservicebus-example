using Core;
using System;

namespace Notifications.Domain
{
    public class Message : AggregateRootBase
    {
        public DateTime MessageDateTimeSent { get; }
        public string Destination { get; }
        public string Title { get; }
        public string Content { get; }
        public MessageSendStatus Status { get; private set; }

        private Message(string title, string content, string destination)
        {
            Title = title;
            Content = content;
            Destination = destination;
            Status = MessageSendStatus.Created;
        }

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

        public static Message CreateAsSMS(string content, string destination)
        {
            return new Message(content, destination);
        }

        public static Message CreateAsEmail(string title, string content, string destination)
        {
            return new Message(title, content, destination);
        }
    }
}
