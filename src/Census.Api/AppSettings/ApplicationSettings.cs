using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class ApplicationSettings : IConfigurationSetting
    {
        [Required]
        public string Name { get; set; }
    }
}