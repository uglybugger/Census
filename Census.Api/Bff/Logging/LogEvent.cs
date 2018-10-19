using System;

namespace Census.Api.Bff.Logging
{
    public class LogEvent
    {
        public DateTimeOffset Timestamp { get; set; }
        public StructuredLogLevel Level { get; set; }
        public MessageTemplate MessageTemplate { get; set; }
    }
}