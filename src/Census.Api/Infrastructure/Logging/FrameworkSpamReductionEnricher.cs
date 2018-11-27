using System.Reflection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Serilog.Core;
using Serilog.Events;

namespace Census.Api.Infrastructure.Logging
{
    public class FrameworkSpamReductionEnricher : ILogEventEnricher
    {
        private static readonly FieldInfo _logLevelBackingField = typeof(LogEvent).GetField("<Level>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // if we're logging something important, let it through
            if (logEvent.Level >= LogEventLevel.Warning) return;

            if (IsFrom<ControllerActionInvoker>(logEvent))
            {
                _logLevelBackingField.SetValue(logEvent, LogEventLevel.Verbose);
                return;
            }

            if (IsFrom<ContentResultExecutor>(logEvent))
            {
                _logLevelBackingField.SetValue(logEvent, LogEventLevel.Verbose);
                return;
            }

            if (IsFrom<JsonResultExecutor>(logEvent))
            {
                _logLevelBackingField.SetValue(logEvent, LogEventLevel.Verbose);
                return;
            }

            if (IsFrom<CorsService>(logEvent))
            {
                _logLevelBackingField.SetValue(logEvent, LogEventLevel.Verbose);
            }

            if (IsFrom("Microsoft.AspNetCore.Hosting.Internal.WebHost", logEvent))
            {
                _logLevelBackingField.SetValue(logEvent, LogEventLevel.Verbose);
            }
        }

        private static bool IsFrom<T>(LogEvent logEvent)
        {
            var sourceContext = typeof(T).FullName;

            return IsFrom(sourceContext, logEvent);
        }

        private static bool IsFrom(string sourceContext, LogEvent logEvent)
        {
            if (!logEvent.Properties.TryGetValue("SourceContext", out var value)) return false;

            var scalarValue = value as ScalarValue;
            if (scalarValue == null) return false;

            var stringValue = scalarValue.Value as string;
            if (stringValue == null) return false;

            if (stringValue.Contains(sourceContext)) return true;
            return false;
        }
    }
}