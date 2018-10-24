using System;
using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class SeqSettings : IConfigurationSetting
    {
        [Required]
        public Uri Uri { get; set; }

        [Required]
        public string ApiKey { get; set; }
    }
}