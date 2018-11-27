import BrowserIdEnricher from "./BrowserIdEnricher";
const StructuredLog = require('structured-log');
const SeqSink = require('structured-log-seq-sink')

class LogBootstrapper {
    constructor(configuration, version) {
        this.configuration = configuration;
        this.version = version;

        this.bootstrap = this.bootstrap.bind(this);
    }

    bootstrap() {

        var levelSwitch = new StructuredLog.DynamicLevelSwitch(this.configuration.Logging.LogEventLevel)

        var consoleSink = new StructuredLog.ConsoleSink({
            console: this.undecoratedConsole,
            includeTimestamps: true,
        });

        var seqSink = new SeqSink({
            url: this.configuration.Logging.Seq.Uri,
            apiKey: this.configuration.Logging.Seq.ApiKey,
            levelSwitch: levelSwitch,
            suppressErrors: false
        });

        var logger = StructuredLog.configure()
            .enrich({
                "ApplicationName": "Hipster Census",
                "ApplicationVersion": this.version.Version,
                "ProcessName": "browser"
            })
            .enrich(new BrowserIdEnricher().enrich)
            .writeTo(consoleSink)
            .writeTo(seqSink)
            .create();

        logger.info("Application online");

        return logger;
    }
}

export default LogBootstrapper;