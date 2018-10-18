using System.Net.Http;

namespace Census.Contracts.HttpRequestRouting.Attributes
{
    public class PostAttribute : RoutingAttribute
    {
        public override HttpMethod Method { get; } = HttpMethod.Post;
        public override string RelativePath { get; }

        public PostAttribute(string relativePath)
        {
            RelativePath = relativePath;
        }
    }
}