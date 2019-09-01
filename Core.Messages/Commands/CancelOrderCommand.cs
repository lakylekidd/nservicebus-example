using System;

namespace Core.Messages.Commands
{
    public class CancelOrderCommand : Command
    {
        public Guid OrderId { get; }
        public DateTime OrderCancellationDateTime { get; }

        public CancelOrderCommand(Guid id)
        {
            OrderId = id;
            OrderCancellationDateTime = DateTime.Now;
        }
    }
}
