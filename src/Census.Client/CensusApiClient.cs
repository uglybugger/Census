using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Census.Contracts;
using Census.Contracts.HttpRequestRouting.Attributes;
using Census.Contracts.Validation;
using Newtonsoft.Json;

namespace Census.Client
{
    public class CensusApiClient : IDisposable
    {
        private readonly Uri _apiEndpoint;

        private static readonly RateLimiter _rateLimiter = new RateLimiter(100, TimeSpan.FromSeconds(1));
        private static readonly HttpClient _httpClient = new HttpClient();

        public CensusApiClient(Uri apiEndpoint)
        {
            _apiEndpoint = apiEndpoint;

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken)
        {
            await MakeHttpRequest(command, cancellationToken);
        }

        public async Task<TResponse> Request<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
            where TRequest : IRequest<TRequest, TResponse>
            where TResponse : IResponse
        {
            var httpResponse = await MakeHttpRequest(request, cancellationToken);
            var json = await httpResponse.Content.ReadAsStringAsync();
            var response = (TResponse) JsonConvert.DeserializeObject(json, typeof(TResponse));
            return response;
        }

        private async Task<HttpResponseMessage> MakeHttpRequest(object dto, CancellationToken cancellationToken)
        {
            await _rateLimiter.Wait();

            AssertValidPayload(dto);

            var requestRoute = RequestRouteFor(dto);
            var requestUri = new Uri(_apiEndpoint, requestRoute.RelativePath);
            var request = new HttpRequestMessage(requestRoute.Method, requestUri);
            var json = JsonConvert.SerializeObject(dto);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.SendAsync(request, cancellationToken);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                ex.Data["Content"] = content;
                throw;
            }

            return httpResponse;
        }

        private static void AssertValidPayload(object dto)
        {
            var validationFailures = RecursiveValidator.ValidateObject(dto).ToArray();
            if (validationFailures.Any())
            {
                // make it look just like the request actually went over the wire, even though we failed it locally.
                var ex = new HttpRequestException("Response status code does not indicate success: 400 (Bad Request).");
                ex.Data["Content"] = JsonConvert.SerializeObject(validationFailures);
                throw ex;
            }
        }

        private static RequestRoute RequestRouteFor(object dto)
        {
            var routingAttribute = dto.GetType().GetCustomAttributes<RoutingAttribute>().Single();
            return new RequestRoute(routingAttribute.Method, routingAttribute.RelativePath);
        }

        public void Dispose()
        {
            _rateLimiter?.Dispose();
        }
    }
}