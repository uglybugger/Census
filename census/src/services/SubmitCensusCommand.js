class SubmitCensusCommand {

    constructor(submission) {
        this.Submission = submission;
    }

    get route() {
        return "api/census/submit";
    }
}

export default SubmitCensusCommand;