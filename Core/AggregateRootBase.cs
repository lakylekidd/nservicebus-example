using System;

namespace Core
{
    public class AggregateRootBase: IAggregateRootBase
    {
        public Guid AggregateId { get; protected set; }

        public AggregateRootBase()
        {
            AggregateId = Guid.NewGuid();
        }
    }
}
