using System.Threading.Tasks;
using Census.Api.Domain.Features.CensusSubmission;
using Census.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Api
{
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        [HttpPost]
        [Route(SubmitCensusCommand.RouteTemplate)]
        public async Task<IActionResult> Submit(SubmitCensusCommand command)
        {
            var handler = new SubmitCensusCommandHandler();
            await handler.Handle(command);
            return new EmptyResult();
        }
    }
}