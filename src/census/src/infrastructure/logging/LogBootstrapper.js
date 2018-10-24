import BrowserIdEnricher from "./BrowserIdEnricher";
const StructuredLog = require('structured-log');
const SeqSink = require('structured-log-seq-sink')

class LogBootstrapper {
    constructor(configuration) {
        this.configuration = configuration;

        this.bootstrap = this.bootstrap.bind(this);
    }

    bootstrap() {

        this.undecoratedConsole = {
            log: console.log,
            debug: console.debug,
            info: console.info,
            warn: console.warn,
            error: console.error
        };

        var levelSwitch = new StructuredLog.DynamicLevelSwitch(this.configuration.Logging.LogEventLevel)

        var consoleSink = new StructuredLog.ConsoleSink({
            console: this.undecoratedConsole,
            includeTimestamps: true,
        });

        var seqSink = new SeqSink({
            url: this.configuration.Logging.Seq.Uri,
            apiKey: this.configuration.Logging.Seq.ApiKey,
            levelSwitch: levelSwitch
        });

        var logger = StructuredLog.configure()
            .enrich({
                "ApplicationName": this.configuration.Application.Name,
                "ApplicationVersion": this.configuration.Application.Version,
                "ProcessName": "react"
            })
            .enrich(new BrowserIdEnricher().enrich)
            .writeTo(consoleSink)
            .writeTo(seqSink)
            .create();

        console.log = logger.debug.bind(logger);
        console.debug = logger.debug.bind(logger);
        console.info = logger.info.bind(logger);
        console.warn = logger.warn.bind(logger);
        console.error = logger.error.bind(logger);

        console.info("Application online");
    }
}

export default LogBootstrapper;