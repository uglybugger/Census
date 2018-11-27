using System;

namespace Census.Api.Domain.Features.CensusSubmission
{
    public class CensusForm : AggregateRoot
    {
        protected CensusForm()
        {
        }

        public CensusForm(Guid id, string accessToken, string legalName, string baristaName, int beardLength, int gearInches, int beerBitterness, string favouriteBand) : base(id)
        {
            AccessToken = accessToken;
            LegalName = legalName;
            BaristaName = baristaName;
            BeardLength = beardLength;
            GearInches = gearInches;
            BeerBitterness = beerBitterness;
            FavouriteBand = favouriteBand;
        }

        public string AccessToken { get; protected set; }
        public string LegalName { get; protected set; }
        public string BaristaName { get; protected set; }
        public int BeardLength { get; protected set; }
        public int GearInches { get; protected set; }
        public int BeerBitterness { get; protected set; }
        public string FavouriteBand { get; protected set; }
        public int HowLongIsYourBeard { get; protected set; }
        public int NumberOfGearInchesOnYourFixie { get; protected set; }
    }
}