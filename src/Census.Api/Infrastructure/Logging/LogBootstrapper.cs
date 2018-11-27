using Census.Api.AppSettings;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers;
using Serilog.Events;

namespace Census.Api.Infrastructure.Logging
{
    public static class LogBootstrapper
    {
        public static void Bootstrap(ApplicationSettings applicationSettings, LoggingSettings loggingSettings)
        {
            var controlLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);

            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.ControlledBy(controlLevelSwitch)
                         .Enrich.FromLogContext()
                         .Enrich.WithProperty("ApplicationName", applicationSettings.Name)
                         .Enrich.WithProperty("ApplicationVersion", typeof(LogBootstrapper).Assembly.GetName().Version)
                         .Enrich.With<FrameworkSpamReductionEnricher>()
                         .Enrich.With<MachineNameEnricher>()
                         .Enrich.With<EnvironmentUserNameEnricher>()
                         .Enrich.With<ThreadIdEnricher>()
                         .Enrich.With<ProcessIdEnricher>()
                         .Enrich.With<ProcessNameEnricher>()
                         .Enrich.With<ExceptionDataEnricher>()
                         .WriteTo.Seq(loggingSettings.Seq.Uri.ToString(),
                                      apiKey: loggingSettings.Seq.ApiKey,
                                      controlLevelSwitch: controlLevelSwitch)
                         .CreateLogger();

            Log.Information("Application online");
        }
    }
}