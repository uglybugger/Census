using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public class AutofacMediator : IMediator
    {
        private readonly ILifetimeScope _lifetimeScope;

        public event EventHandler<CommandSentEventArgs> CommandSent;
        public event EventHandler<EventPublishedEventArgs> EventPublished;
        public event EventHandler<ResponseReturnedEventArgs> ResponseReturned;

        public AutofacMediator(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
        {
            var handler = _lifetimeScope.Resolve<IHandleCommand<TCommand>>();
            await handler.Handle(command, cancellationToken);

            CommandSent?.Invoke(this, new CommandSentEventArgs(command));
        }

        public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent
        {
            var handlers = _lifetimeScope.Resolve<IHandleEvent<TEvent>[]>();
            foreach (var handler in handlers)
            {
                await handler.Handle(@event, cancellationToken);
            }

            EventPublished?.Invoke(this, new EventPublishedEventArgs(@event));
        }

        public async Task<TResponse> Request<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
            where TRequest : IRequest<TRequest, TResponse>
            where TResponse : IResponse
        {
            var handler = _lifetimeScope.Resolve<IHandleRequest<TRequest, TResponse>>();
            var response = await handler.Handle(request, cancellationToken);

            ResponseReturned?.Invoke(this, new ResponseReturnedEventArgs(request, response));

            return response;
        }
    }
}