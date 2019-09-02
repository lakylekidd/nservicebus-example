using System;

namespace Core.Messages.Commands
{
    public class PlaceOrderCommand : Command
    {
        public DateTime OrderDateTime { get; private set; }

        public PlaceOrderCommand()
        {
            OrderDateTime = DateTime.Now;
        }
    }
}
