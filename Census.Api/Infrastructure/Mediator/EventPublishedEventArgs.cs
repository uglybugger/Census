using System;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public class EventPublishedEventArgs : EventArgs
    {
        public IEvent Event { get; }

        public EventPublishedEventArgs(IEvent @event)
        {
            Event = @event;
        }
    }
}