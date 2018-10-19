using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Contracts.Contracts;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmitCensusCommandHandler : IHandleCommand<SubmitCensusCommand>
    {
        private readonly IMediator _mediator;

        public SubmitCensusCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(SubmitCensusCommand command)
        {
            var completedCensus = command.CompletedCensus;
            await _mediator.Publish(new CensusSubmittedEvent(completedCensus));
        }
    }
}