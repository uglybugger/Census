using System;

namespace Census.Api.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        protected AggregateRoot()
        {
        }

        protected AggregateRoot(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; protected set; }
    }
}