using System.IO;
using Census.Api.AppSettings;
using Microsoft.Extensions.Configuration;

namespace Census.Api.Infrastructure.Configuration
{
    public static class ConfigurationBootstrapper
    {
        public static void Bootstrap(string[] args, out IConfiguration configuration, out AppSettingsRoot appSettingsRoot)
        {
            configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .AddCommandLine(args)
                            .Build();

            appSettingsRoot = configuration.Get<AppSettingsRoot>();
        }
    }
}