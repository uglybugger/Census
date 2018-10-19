using System;
using Microsoft.AspNetCore;
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
                LogBootstrapper.Bootstrap(); //TODO up to here

                var builder = CreateWebHostBuilder(args);
                var webHost = builder.Build();
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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}