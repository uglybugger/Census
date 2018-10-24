using System.Threading;
using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public interface IHandleRequest<TRequest, TResponse>
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        Task<TResponse> Handle(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken);
    }
}