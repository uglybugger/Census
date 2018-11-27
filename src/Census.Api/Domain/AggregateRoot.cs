using System;

namespace Census.Api.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        private Guid _id;

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(Guid id)
        {
            this.id = id;
        }

        public Guid id
        {
            get => _id;
            protected set
            {
                _id = value;
                PartitionKey = Math.Abs(value.GetHashCode()) % 10;
            }
        }

        public int PartitionKey { get; protected set; }
    }
}