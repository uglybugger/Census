using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public interface IMediator
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;

        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;

        Task<TResponse> Request<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TRequest, TResponse>
            where TResponse : IResponse;
    }
}