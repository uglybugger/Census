using System.Threading.Tasks;
using Census.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmissionController : Controller
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