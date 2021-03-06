﻿using Autofac;
using Census.Api.Infrastructure.Mediator;
using Serilog;

namespace Census.Api.AutofacModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AutofacMediator>()
                .AsImplementedInterfaces()
                .OnActivated(args =>
                {
                    var logger = args.Context.Resolve<ILogger>().ForContext<AutofacMediator>();
                    args.Instance.CommandSent += (sender, e) => logger.Verbose("Command {MessageType} sent", e.Command.GetType().FullName);
                    args.Instance.EventPublished += (sender, e) => logger.Verbose("Event {MessageType} published", e.Event.GetType().FullName);
                    args.Instance.ResponseReturned += (sender, e) => logger.Verbose("Response {MessageType} returned", e.Response.GetType().FullName);
                })
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IHandleCommand<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IHandleEvent<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IHandleRequest<,>))
                .InstancePerLifetimeScope();
        }
    }
}