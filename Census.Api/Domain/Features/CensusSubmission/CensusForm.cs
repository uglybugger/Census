using System;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class CensusForm : AggregateRoot
    {
        protected CensusForm()
        {
        }

        public CensusForm(Guid id, string accessToken, int beardLength, int gearInches) : base(id)
        {
            AccessToken = accessToken;
            BeardLength = beardLength;
            GearInches = gearInches;
        }

        public string AccessToken { get; protected set; }
        public int BeardLength { get; }
        public int GearInches { get; }
        public int HowLongIsYourBeard { get; protected set; }
        public int NumberOfGearInchesOnYourFixie { get; protected set; }
    }
}