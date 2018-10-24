using System.Threading;
using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public interface IMediator
    {
        Task Send<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;

        Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent;

        Task<TResponse> Request<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
            where TRequest : IRequest<TRequest, TResponse>
            where TResponse : IResponse;
    }
}