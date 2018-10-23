import BrowserIdEnricher from "./BrowserIdEnricher";
const StructuredLog = require('structured-log');
const SeqSink = require('structured-log-seq-sink')

class LogBootstrapper {

    bootstrap() {
        
        this.undecoratedConsole = {
            log: console.log,
            debug: console.debug,
            info: console.info,
            warn: console.warn,
            error: console.error
        };

        var levelSwitch = new StructuredLog.DynamicLevelSwitch("verbose")

        var consoleSink = new StructuredLog.ConsoleSink({
            console: this.undecoratedConsole,
            includeTimestamps: true,
        });

        var seqSink = new SeqSink({
            url: "http://localhost:5341",
            apiKey: "",
            levelSwitch: levelSwitch
        });

        var logger = StructuredLog.configure()
            .enrich({
                "ApplicationName": "Hipster Census React",
                "ApplicationVersion": "1.0.0.0",
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