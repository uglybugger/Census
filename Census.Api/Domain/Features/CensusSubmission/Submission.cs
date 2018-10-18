using System;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class Submission
    {
        public Guid Id { get; protected set; }
        public int HowLongIsYourBeard { get; protected set; }
        public int NumberOfGearInchesOnYourFixie { get; protected set; }
    }
}