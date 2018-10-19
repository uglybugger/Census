using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Infrastructure.Mediator
{
    public interface IHandleCommand<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}