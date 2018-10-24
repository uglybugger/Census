namespace Census.Contracts
{
    public interface IRequest
    {
    }

    public interface IRequest<TRequest, TResponse> : IRequest
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
    }
}