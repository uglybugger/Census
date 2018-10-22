using System.ComponentModel.DataAnnotations;

namespace Census.Api.AppSettings
{
    public class PersistenceSettings : IConfigurationSetting
    {
        [Required]
        public CosmosDbSettings CosmosDb { get; set; }
    }
}