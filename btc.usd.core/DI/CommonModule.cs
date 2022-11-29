using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Core.App.Services;
using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;

namespace Domain.DI
{
    internal class CommonModule : Module
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
            
            builder.RegisterType<HistoryAdaptor>().AsSelf();
            builder.RegisterType<BitStampAdaptor<BitStampModel, TbBitStamp>>().AsSelf();
            builder.RegisterType<BitFinexAdaptor<BitFinexModel, TbBitFinex>>().AsSelf();
        }
    }
}
