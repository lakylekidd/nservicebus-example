using System;

namespace Core.Messages.Commands
{
    public class CancelOrderCommand : Command
    {
        public Guid OrderId { get; private set; }
        public DateTime OrderCancellationDateTime { get; private set; }

        public CancelOrderCommand(Guid id)
        {
            OrderId = id;
            OrderCancellationDateTime = DateTime.Now;
        }
    }
}
