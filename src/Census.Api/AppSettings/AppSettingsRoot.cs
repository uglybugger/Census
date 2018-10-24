using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class AppSettingsRoot : IConfigurationSetting
    {
        [Required]
        public ApplicationSettings Application { get; set; }

        [Required]
        public LoggingSettings Logging { get; set; }

        [Required]
        public HostingSettings Hosting { get; set; }

        [Required]
        public PersistenceSettings Persistence { get; set; }
    }
}