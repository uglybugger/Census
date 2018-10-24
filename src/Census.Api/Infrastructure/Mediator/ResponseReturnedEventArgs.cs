using System;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public class ResponseReturnedEventArgs : EventArgs
    {
        public IRequest Request { get; }
        public IResponse Response { get; }

        public ResponseReturnedEventArgs(IRequest request, IResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}