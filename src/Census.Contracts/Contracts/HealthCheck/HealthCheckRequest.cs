using Census.Contracts.Contracts.HealthCheck;

namespace Census.Contracts.Contracts
{
    public class HealthCheckRequest: IRequest<HealthCheckRequest, HealthCheckResponse>
    {
        public const string RouteTemplate = "api/healthcheck";
    }
}