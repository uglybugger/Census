using System.Threading.Tasks;
using Census.Api.Infrastructure.Mediator;
using Census.Api.Infrastructure.Persistence;
using Census.Contracts.Contracts;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class SubmitCensusCommandHandler : IHandleCommand<SubmitCensusCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CensusForm> _repository;

        public SubmitCensusCommandHandler(IMediator mediator, IRepository<CensusForm> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task Handle(SubmitCensusCommand command)
        {
            var dto = command.CompletedCensus;
            var censusForm = new CensusForm(dto.Id, dto.AccessToken, dto.BeardLength, dto.GearInches);
            await _repository.Add(censusForm);

            await _mediator.Publish(new CensusSubmittedEvent(dto));
        }
    }
}