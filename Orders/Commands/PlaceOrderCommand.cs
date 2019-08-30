using System;

namespace Orders.Commands
{
    public class PlaceOrderCommand : Command
    {
        public DateTime OrderDate { get; }

        public PlaceOrderCommand(Guid id)
            :base(id)
        {
            OrderDate = DateTime.Now;
        }
    }
}
