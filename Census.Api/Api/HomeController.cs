using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new ContentResult
            {
                Content = "Hello, world!",
                ContentType = "text/plain"
            };

            return response;
        }
    }
}