using System;
using Census.Api.Infrastructure.Configuration;
using Census.Api.Infrastructure.Hosting;
using Census.Api.Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Census.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bootstrapping...");
                ConfigurationBootstrapper.Bootstrap(args, out var configuration, out var appSettingsRoot);
                LogBootstrapper.Bootstrap(appSettingsRoot.Application, appSettingsRoot.Logging);
                WebHostBootstrapper.Bootstrap<Startup>(configuration, out var webHost);

                Log.Debug("Starting web host");
                webHost.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "A fatal exception occurred.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return 0;
        }
    }
}