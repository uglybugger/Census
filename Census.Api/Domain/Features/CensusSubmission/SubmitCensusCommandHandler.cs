using System.Threading.Tasks;
using Census.Api.Contracts;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmitCensusCommandHandler: IHandleCommand<SubmitCensusCommand>
    {
        public Task Handle(SubmitCensusCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}