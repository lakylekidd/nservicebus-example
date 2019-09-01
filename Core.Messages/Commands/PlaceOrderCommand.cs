using System;

namespace Core.Messages.Commands
{
    public class PlaceOrderCommand : Command
    {
        public DateTime OrderDateTime { get; }

        public PlaceOrderCommand()
        {
            OrderDateTime = DateTime.Now;
        }
    }
}
