using System.Threading;
using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Api
{
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HealthCheckController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route(HealthCheckRequest.RouteTemplate)]
        [HttpGet]
        public async Task<IActionResult> Index(HealthCheckRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Request(request, cancellationToken);
            return new JsonResult(response);
        }
    }
}