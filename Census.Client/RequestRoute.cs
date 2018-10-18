using System.Net.Http;

namespace Census.Client
{
    internal class RequestRoute
    {
        public HttpMethod Method { get; }
        public string RelativePath { get; }

        public RequestRoute(HttpMethod method, string relativePath)
        {
            Method = method;
            RelativePath = relativePath;
        }
    }
}