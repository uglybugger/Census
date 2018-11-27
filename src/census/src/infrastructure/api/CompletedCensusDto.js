import ArgumentNullError from '../../errors/ArgumentNullError';

class CompletedCensusDto {
    constructor(id, accessToken, legalName, baristaName, beardLength, gearInches, beerBitterness, favouriteBand) {
        if (!id) throw new ArgumentNullError(id);
        if (!accessToken) throw new ArgumentNullError(accessToken);
        if (!legalName) throw new ArgumentNullError(legalName);
        if (!baristaName) throw new ArgumentNullError(baristaName);
        if (!beardLength) throw new ArgumentNullError(beardLength);
        if (!gearInches) throw new ArgumentNullError(gearInches);
        if (!beerBitterness) throw new ArgumentNullError(beerBitterness);
        if (!favouriteBand) throw new ArgumentNullError(favouriteBand);

        this.id = id;
        this.accessToken = accessToken;
        this.legalName = legalName;
        this.baristaName = baristaName;
        this.beardLength = beardLength;
        this.gearInches = gearInches;
        this.beerBitterness = beerBitterness;
        this.favouriteBand = favouriteBand;
    }
}

export default CompletedCensusDto;
