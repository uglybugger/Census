using System.Threading;
using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts;
using Census.Contracts.Contracts;
using Census.Contracts.Contracts.HealthCheck;

namespace Census.Api.Domain.Features.HealthCheck
{
    public class HealthCheckRequestHandler : IHandleRequest<HealthCheckRequest, HealthCheckResponse>
    {
        public Task<HealthCheckResponse> Handle(IRequest<HealthCheckRequest, HealthCheckResponse> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HealthCheckResponse());
        }
    }
}