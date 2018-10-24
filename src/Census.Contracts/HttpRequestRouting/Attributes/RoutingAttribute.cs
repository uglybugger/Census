using System;
using System.Net.Http;

namespace Census.Contracts.HttpRequestRouting.Attributes
{
    public abstract class RoutingAttribute : Attribute
    {
        public abstract HttpMethod Method { get; }
        public abstract string RelativePath { get; }
    }
}