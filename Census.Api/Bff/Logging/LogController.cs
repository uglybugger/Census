using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

namespace Census.Api.Bff.Logging
{
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger _logger;

        public LogController(ILogger logger)
        {
            _logger = logger.ForContext("Source", "React");
        }

        [HttpPost]
        [Route(LogCommand.RouteTemplate)]
        public IActionResult Index([FromBody] LogCommand command)
        {
            foreach (var logEvent in command.LogEvents)
            {
                var logEventLevel = MapToSerilogLevel(logEvent.Level);
                _logger.Write(logEventLevel, logEvent.MessageTemplate.Raw, logEvent.MessageTemplate.Tokens);
            }

            return new EmptyResult();
        }

        private static LogEventLevel MapToSerilogLevel(StructuredLogLevel structuredLogLevel)
        {
            switch (structuredLogLevel)
            {
                case StructuredLogLevel.Fatal:
                    return LogEventLevel.Fatal;
                case StructuredLogLevel.Error:
                    return LogEventLevel.Error;
                case StructuredLogLevel.Warning:
                    return LogEventLevel.Warning;
                case StructuredLogLevel.Information:
                    return LogEventLevel.Information;
                case StructuredLogLevel.Debug:
                    return LogEventLevel.Debug;
                case StructuredLogLevel.Verbose:
                    return LogEventLevel.Verbose;
                default:
                    return LogEventLevel.Verbose;
            }
        }
    }
}