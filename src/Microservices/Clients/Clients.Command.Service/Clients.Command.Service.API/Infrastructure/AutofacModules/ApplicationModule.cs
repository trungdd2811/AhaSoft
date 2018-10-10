using Autofac;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using Clients.Command.Service.Infrastructure.Repositories;

namespace Clients.Command.Service.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
