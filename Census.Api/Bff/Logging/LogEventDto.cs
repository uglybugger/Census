using System;

namespace Census.Api.Bff.Logging
{
    public class LogEventDto
    {
        public DateTimeOffset Timestamp { get; set; }
        public StructuredLogLevel Level { get; set; }
        public MessageTemplateDto MessageTemplate { get; set; }
    }
}