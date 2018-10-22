using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class HostingSettings : IConfigurationSetting
    {
        [Required]
        public CorsSettings Cors { get; set; }
    }
}