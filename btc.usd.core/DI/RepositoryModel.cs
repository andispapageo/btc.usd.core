using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Core.App.Services;
using Core.Interfaces.Interfaces.IData;
using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;
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
            //Adaptors
            builder.RegisterType<BitStampAdaptor<BitStampModel, TbBitStamp>>().AsSelf();
            builder.RegisterType<BitFinexAdaptor<BitFinexModel, TbBitFinex>>().AsSelf();

            builder.RegisterType<DomainRepository<TbBitStamp>>().As<IRepository<TbBitStamp>>();
            builder.RegisterType<DomainUnitOfWork<TbBitStamp>>().As<IUnitOfWork<TbBitStamp>>();

            builder.RegisterType<DomainRepository<TbBitFinex>>().As<IRepository<TbBitFinex>>();
            builder.RegisterType<DomainUnitOfWork<TbBitFinex>>().As<IUnitOfWork<TbBitFinex>>();
        }
    }
}
