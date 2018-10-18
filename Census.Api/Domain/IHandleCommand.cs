using System.Threading.Tasks;
using Census.Contracts;

namespace Census.Api.Domain
{
    public interface IHandleCommand<TCommand> where TCommand: ICommand
    {
        Task Handle(TCommand command);
    }
}