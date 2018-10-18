using System.Threading.Tasks;
using Census.Contracts.Contracts;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmitCensusCommandHandler: IHandleCommand<SubmitCensusCommand>
    {
        public async Task Handle(SubmitCensusCommand command)
        {
        }
    }
}