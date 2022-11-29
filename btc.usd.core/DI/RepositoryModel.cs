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

            builder.RegisterType<DomainRepository<TbBitStamp>>().As<IRepository<TbBitStamp>>();
            builder.RegisterType<DomainUnitOfWork<TbBitStamp>>().As<IUnitOfWork<TbBitStamp>>();

            builder.RegisterType<DomainRepository<TbBitFinex>>().As<IRepository<TbBitFinex>>();
            builder.RegisterType<DomainUnitOfWork<TbBitFinex>>().As<IUnitOfWork<TbBitFinex>>();

        }
    }
}
