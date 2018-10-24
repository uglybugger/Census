using Autofac;
using Serilog;

namespace Census.Api.AutofacModules
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => Log.Logger)
                .SingleInstance()
                .ExternallyOwned();
        }
    }
}