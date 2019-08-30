using System;

namespace Core
{
    public class Aggregate: IAggregateRootBase
    {
        public Guid Id { get; protected set; }

        public Aggregate()
        {
            
        }
    }
}
