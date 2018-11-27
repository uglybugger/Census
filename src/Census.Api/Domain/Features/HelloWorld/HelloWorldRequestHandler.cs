using System.Threading;
using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts;
using Census.Contracts.Contracts;
using Census.Contracts.Contracts.HelloWorld;

namespace Census.Api.Domain.Features.HelloWorld
{
    public class HelloWorldRequestHandler : IHandleRequest<HelloWorldRequest, HelloWorldResponse>
    {
        public Task<HelloWorldResponse> Handle(IRequest<HelloWorldRequest, HelloWorldResponse> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HelloWorldResponse());
        }
    }
}