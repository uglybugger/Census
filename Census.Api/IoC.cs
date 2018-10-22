using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Census.Api.AppSettings;
using Census.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Census.Api
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(IServiceCollection services, AppSettingsRoot appSettingsRoot)
        {
            var assembliesToScan = new[] {typeof(IoC).Assembly};

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyModules(assembliesToScan);
            RegisterConfigurationSettings(builder, appSettingsRoot); // TODO use ConfigInjector
            return builder.Build();
        }

        private static void RegisterConfigurationSettings(ContainerBuilder builder, AppSettingsRoot appSettingsRoot)
        {
            new[] {appSettingsRoot}
                .Cast<IConfigurationSetting>()
                .DepthFirst(ExtractSettingsObjects)
                .Do(setting => builder.RegisterInstance(setting)
                                      .AsSelf()
                                      .ExternallyOwned())
                .Done();
        }

        private static IEnumerable<IConfigurationSetting> ExtractSettingsObjects(IConfigurationSetting settingsObject)
        {
            var properties = settingsObject.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(settingsObject) as IConfigurationSetting;
                if (value != null) yield return value;
            }
        }
    }
}