class SubmitCensusCommand {

    constructor(completedCensusDto) {
        this.CompletedCensus = completedCensusDto;
    }

    get route() {
        return "api/census/submit";
    }
}

export default SubmitCensusCommand;