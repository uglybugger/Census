using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Census.Contracts;
using Census.Contracts.HttpRequestRouting.Attributes;
using Newtonsoft.Json;

namespace Census.Client
{
    public class CensusApiClient : IDisposable
    {
        private readonly Uri _apiEndpoint;

        private static readonly RateLimiter _rateLimiter = new RateLimiter();
        private static readonly HttpClient _httpClient = new HttpClient();

        public CensusApiClient(Uri apiEndpoint)
        {
            _apiEndpoint = apiEndpoint;
        }

        public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken)
        {
            await _rateLimiter.Wait();

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

            var requestRoute = RequestRouteFor(dto);
            var requestUri = new Uri(_apiEndpoint, requestRoute.RelativePath);
            var request = new HttpRequestMessage(requestRoute.Method, requestUri);
            var json = JsonConvert.SerializeObject(dto);
            request.Content = new StringContent(json);

            var httpResponse = await _httpClient.SendAsync(request, cancellationToken);
            httpResponse.EnsureSuccessStatusCode();

            return httpResponse;
        }

        private static RequestRoute RequestRouteFor(object dto)
        {
            var routingAttribute = dto.GetType().GetCustomAttributes<RoutingAttribute>().Single();
            return new RequestRoute(routingAttribute.Method, routingAttribute.RelativePath);
        }

        public void Dispose()
        {
        }
    }
}