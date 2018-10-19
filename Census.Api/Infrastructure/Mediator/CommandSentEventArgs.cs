using System;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public class CommandSentEventArgs : EventArgs
    {
        public ICommand Command { get; }

        public CommandSentEventArgs(ICommand command)
        {
            Command = command;
        }
    }
}