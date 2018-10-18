using System.Threading.Tasks;

namespace Census.Api.Domain
{
    public interface IHandleCommand<TCommand> where TCommand: ICommand
    {
        Task Handle(TCommand command);
    }
}