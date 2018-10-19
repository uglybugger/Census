class LogCommand {

    constructor(logEvents) {
        this.LogEvents = logEvents;
    }

    get route() {
        return "bff/log";
    }
}

export default LogCommand;