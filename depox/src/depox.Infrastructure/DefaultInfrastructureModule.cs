using Autofac;
using depox.Core;
using depox.Core.Interfaces;
using depox.Infrastructure.Data;
using depox.Infrastructure.DomainEvents;
using depox.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using depox.Core.Entities;
using depox.SharedKernel;
using Module = Autofac.Module;

namespace depox.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;
        private List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(DatabasePopulator));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository<BaseEntity>));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventDispatcher>().As<IDomainEventDispatcher>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<ToDoItem>>().As<IRepository<ToDoItem>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<Bin>>().As<IRepository<Bin>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Item>>().As<IRepository<Item>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Stock>>().As<IRepository<Stock>>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(typeof(IHandle<>));

            builder.RegisterType<EmailSender>().As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }

    }
}
