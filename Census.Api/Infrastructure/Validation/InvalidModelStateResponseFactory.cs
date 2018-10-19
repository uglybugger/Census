using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Census.Api.Infrastructure
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult CreateResponse(ActionContext context)
        {
            var modelState = context.ModelState;
            var errors = modelState.Keys.Select(k => new Error{Key = k, Messages= modelState[k].Errors.Select(e => e.ErrorMessage).ToArray()}).ToArray();
            var response = new ErrorResponse
            {
                ErrorCollection = errors
            };

            return new JsonResult(response) {StatusCode = (int) HttpStatusCode.BadRequest};
        }
    }
}