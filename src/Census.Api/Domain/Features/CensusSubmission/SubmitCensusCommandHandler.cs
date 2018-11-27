using System.Diagnostics.CodeAnalysis;
using System.Threading;
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

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public async Task Handle(SubmitCensusCommand command, CancellationToken cancellationToken)
        {
            var dto = command.CompletedCensus;
            var censusForm = new CensusForm(dto.Id.Value,
                                            dto.AccessToken,
                                            dto.LegalName,
                                            dto.BaristaName,
                                            dto.BeardLength.Value,
                                            dto.GearInches.Value,
                                            dto.BeerBitterness.Value,
                                            dto.FavouriteBand);
            await _repository.Add(censusForm);

            await _mediator.Publish(new CensusSubmittedEvent(dto), cancellationToken);
        }
    }
}