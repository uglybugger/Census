using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Api
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public Task<IActionResult> Index()
        {
            var response = new ContentResult
            {
                Content = "Hello, world!",
                ContentType = "text/plain"
            };

            return Task.FromResult((IActionResult) response);
        }
    }
}