using System.Threading;
using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public interface IHandleEvent<TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}