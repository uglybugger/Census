using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Azure.Documents;
using Serilog;

namespace Census.Api.Infrastructure.ActionFilters
{
    public class CosmosRateLimitFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;

        public CosmosRateLimitFilter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                await next();
            }
            catch (DocumentClientException ex)
            {
                await HandleDocumentClientException(context, ex);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DocumentClientException dce) await HandleDocumentClientException(context, dce);
            }
        }

        private async Task HandleDocumentClientException(ActionExecutingContext context, DocumentClientException documentClientException)
        {
            if (documentClientException.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.Warning("Received 429 from CosmosDb. Waiting for {Delay} then returning 429.", documentClientException.RetryAfter);
                await Task.Delay(documentClientException.RetryAfter);

                context.Result = new StatusCodeResult(429);
                return;
            }

            throw documentClientException;
        }
    }
}