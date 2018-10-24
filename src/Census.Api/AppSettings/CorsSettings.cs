using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class CorsSettings : IConfigurationSetting
    {
        [Required]
        public string[] AllowedOrigins { get; set; }
    }
}