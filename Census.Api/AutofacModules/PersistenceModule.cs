using Autofac;
using Census.Api.Infrastructure.Persistence;
using Microsoft.Azure.Documents.Client;

namespace Census.Api.AutofacModules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DocumentClientFactory>()
                .AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<DocumentClientFactory>().Create())
                .As<DocumentClient>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(CosmosDbRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}