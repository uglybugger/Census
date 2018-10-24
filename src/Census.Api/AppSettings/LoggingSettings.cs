using System.ComponentModel.DataAnnotations;
using Serilog.Events;

namespace Census.Api.AppSettings
{
    public class LoggingSettings : IConfigurationSetting
    {
        [Required]
        public string Environment { get; set; }

        [Required]
        public LogEventLevel LogEventLevel { get; set; }

        [Required]
        public SeqSettings Seq { get; set; }
    }
}