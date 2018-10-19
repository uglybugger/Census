using Census.Api.Infrastructure.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers;
using Serilog.Events;

namespace Census.Api
{
    public static class LogBootstrapper
    {
        public static void Bootstrap()
        {
            var controlLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(controlLevelSwitch)
                .Enrich.WithProperty("ApplicationName", "Hipster Census")
                .Enrich.WithProperty("Version", typeof(LogBootstrapper).Assembly.GetName().Version)
                .Enrich.WithProperty("Environment", "Development") //TODO source from configs
                .Enrich.With<FrameworkSpamReductionEnricher>()
                .Enrich.With<MachineNameEnricher>()
                .Enrich.With<EnvironmentUserNameEnricher>()
                .Enrich.With<ThreadIdEnricher>()
                .Enrich.With<ProcessIdEnricher>()
                .Enrich.With<ProcessNameEnricher>()
                .Enrich.With<ExceptionDataEnricher>()
                .WriteTo.Seq("http://localhost:5341", controlLevelSwitch: controlLevelSwitch) //TODO source from configs
                .CreateLogger();

            Log.Information("Application online");
        }
    }
}