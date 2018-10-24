using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Census.Api.Infrastructure.Hosting
{
    public class WebHostBootstrapper
    {
        public static void Bootstrap<TStartup>(IConfiguration configuration, out IWebHost webHost) where TStartup : class
        {
            webHost = WebHost.CreateDefaultBuilder()
                             .UseConfiguration(configuration)
                             .UseStartup<TStartup>()
                             .CaptureStartupErrors(false) // let the exceptions flow. Don't capture/swallow them.
                             .UseSerilog()
                             .Build();
        }
    }
}