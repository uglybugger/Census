using System;

namespace Census.Api.Domain
{
    public interface IAggregateRoot
    {
        Guid id { get; }
    }
}