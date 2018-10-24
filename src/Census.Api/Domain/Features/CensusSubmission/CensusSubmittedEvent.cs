using Census.Contracts;
using Census.Contracts.Contracts;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class CensusSubmittedEvent : IEvent
    {
        public CompletedCensusDto CompletedCensus { get; }

        public CensusSubmittedEvent(CompletedCensusDto completedCensus)
        {
            CompletedCensus = completedCensus;
        }
    }
}