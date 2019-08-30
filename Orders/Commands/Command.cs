using System;

namespace Orders.Commands
{
    public class Command
    {
        public Guid OrderId { get; }

        public Command(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
