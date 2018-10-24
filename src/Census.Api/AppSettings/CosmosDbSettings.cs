using System;
using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class CosmosDbSettings : IConfigurationSetting
    {
        [Required]
        public Uri Endpoint { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string DatabaseName { get; set; }
    }
}