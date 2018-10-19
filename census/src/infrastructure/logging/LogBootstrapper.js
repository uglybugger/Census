import ApiSink from './ApiSink';
const structuredLog = require('structured-log');

class LogBootstrapper {

    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    bootstrap() {
        this.undecoratedConsole = {
            log: console.log,
            debug: console.debug,
            info: console.info,
            warn: console.warn,
            error: console.error
        };

        var consoleSink = new structuredLog.ConsoleSink({ console: this.undecoratedConsole, includeTimestamps: true });
        var apiSink = new ApiSink(this.apiClient);

        var logger = structuredLog.configure()
            .writeTo(consoleSink)
            .writeTo(apiSink)
            .create();

        console.log = logger.debug.bind(logger);
        console.debug = logger.debug.bind(logger);
        console.info = logger.info.bind(logger);
        console.warn = logger.warn.bind(logger);
        console.error = logger.error.bind(logger);
    }
}

export default LogBootstrapper;