using Core;

namespace Orders.Domain
{
    public class OrderAggregate: AggregateRootBase
    {
        public double Amount { get; private set; }
    }
}
