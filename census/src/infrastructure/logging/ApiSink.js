import LogCommand from '../../services/LogCommand';
const structuredLog = require('structured-log');

class ApiSink extends structuredLog.BatchedSink  {
    constructor(apiClient) {
        super(null, { /* options */ });

        this.apiClient = apiClient;
    }

    emitCore(events) {
        var logCommand = new LogCommand(events);
        return this.apiClient.send(logCommand);
    }
}

export default ApiSink;