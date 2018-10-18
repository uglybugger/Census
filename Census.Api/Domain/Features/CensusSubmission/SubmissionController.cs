using System.Threading.Tasks;
using Census.Api.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmissionController : Controller
    {
        [HttpPost]
        [Route(SubmitCensusCommand.RouteTemplate)]
        public async Task<IActionResult> Submit(SubmitCensusCommand command)
        {
            return Content("Hello, world!");
        }
    }
}