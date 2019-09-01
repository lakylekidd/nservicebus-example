using System;

namespace Core.Messages.Commands
{
    public class CancelOrderCommand : Command
    {
        public DateTime OrderCancellationDateTime { get; }

        public CancelOrderCommand(Guid id)
            : base(id)
        {
            OrderCancellationDateTime = DateTime.Now;
        }
    }
}
