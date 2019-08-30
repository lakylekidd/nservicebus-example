using System;

namespace Orders.Commands
{
    public class PlaceOrderCommand : Command
    {
        public DateTime OrderDateTime { get; }

        public PlaceOrderCommand(Guid id)
            :base(id)
        {
            OrderDateTime = DateTime.Now;
        }
    }
}
