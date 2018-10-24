using System.Threading;
using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Api
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index(HelloWorldRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Request(request, cancellationToken);
            return new JsonResult(response);
        }
    }
}