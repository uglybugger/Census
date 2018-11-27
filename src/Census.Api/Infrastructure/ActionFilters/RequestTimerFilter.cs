using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Events;

namespace Census.Api.Infrastructure.ActionFilters
{
    public class RequestTimerFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;

        public RequestTimerFilter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await next();
            }
            finally
            {
                var logEventLevel = context.HttpContext.Response.StatusCode >= 500
                                        ? LogEventLevel.Error
                                        : LogEventLevel.Information;

                _logger.Write(logEventLevel,
                              "HTTP {HttpMethod} to {Url} completed in {Elapsed} with {StatusCode}",
                              context.HttpContext.Request.Method,
                              context.HttpContext.Request.GetDisplayUrl(),
                              sw.Elapsed,
                              context.HttpContext.Response.StatusCode);
            }
        }
    }
}