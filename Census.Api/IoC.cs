using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Census.Api
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(IServiceCollection services)
        {
            var assembliesToScan = new[] {typeof(IoC).Assembly};

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyModules(assembliesToScan);
            return builder.Build();
        }
    }
}