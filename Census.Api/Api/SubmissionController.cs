using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Api
{
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubmissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route(SubmitCensusCommand.RouteTemplate)]
        public async Task<IActionResult> Submit(SubmitCensusCommand command)
        {
            await _mediator.Send(command);
            return new EmptyResult();
        }
    }
}