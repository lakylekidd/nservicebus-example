using System;

namespace Core.Messages.Commands
{
    public class CancelOrderCommand : Command
    {
        public DateTime OrderCancellationDateTime { get; }

        public CancelOrderCommand()
        {
            OrderCancellationDateTime = DateTime.Now;
        }
    }
}
