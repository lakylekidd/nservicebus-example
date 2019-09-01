using System;

namespace Core
{
    public interface IAggregateRootBase
    {
        Guid AggregateId { get; }
    }
}
