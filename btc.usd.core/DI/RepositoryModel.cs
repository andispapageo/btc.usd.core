using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Core.App.Entities.BitFinex;
using Core.App.Entities.BitStamp;
using Core.Interfaces.Interfaces.IData;
using Infastructure.Repositories;

namespace Domain.DI
{
    internal class RepositoryModel : Module
    {
        protected override System.Reflection.Assembly ThisAssembly => base.ThisAssembly;
        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
        {
            base.AttachToComponentRegistration(componentRegistry, registration);
        }

        protected override void AttachToRegistrationSource(IComponentRegistryBuilder componentRegistry, IRegistrationSource registrationSource)
        {
            base.AttachToRegistrationSource(componentRegistry, registrationSource);
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DomainRepository<BitStampModel>>().As<IRepository<BitStampModel>>();
            builder.RegisterType<DomainUnitOfWork<BitStampModel>>().As<IUnitOfWork<BitStampModel>>();

            builder.RegisterType<DomainRepository<BitFinexModel>>().As<IRepository<BitFinexModel>>();
            builder.RegisterType<DomainUnitOfWork<BitFinexModel>>().As<IUnitOfWork<BitFinexModel>>();

        }
    }
}
