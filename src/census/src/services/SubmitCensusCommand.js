class SubmitCensusCommand {

    constructor(completedCensus) {
        this.CompletedCensus = completedCensus;
    }

    get route() {
        return "api/census/submit";
    }
}

export default SubmitCensusCommand;