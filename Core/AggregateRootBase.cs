using System;

namespace Core
{
    public class AggregateRootBase: IAggregateRootBase
    {
        public Guid Id { get; protected set; }

        public AggregateRootBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
