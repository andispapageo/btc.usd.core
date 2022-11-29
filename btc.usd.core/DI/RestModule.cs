using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Infastructure.Rest.BitFinex;
using Infastructure.Rest.BitStamp;

namespace btc.usd.core.DI
{
    public class RestModule : Module
    {
        string url;
        public RestModule(IConfiguration configuration) => Configuration = configuration;
        
        public IConfiguration Configuration { get; }

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
            builder.RegisterType<BitStampRestService<BitStampModel>>().WithParameters(new[] { new NamedParameter(nameof(url), Configuration.GetValue<string>("Sources:BitStamp")) });
            builder.RegisterType<BitFixexRestService<BitFinexModel>>().WithParameters(new[] { new NamedParameter(nameof(url), Configuration.GetValue<string>("Sources:BitFinex")) });
        }
    }
}
