using Autofac;
using Domain.DI;
using Domain.Interfaces;

namespace btc.usd.core.DI.Base
{
    internal class ModulesBox : IDependencyRegister
    {
        public ModulesBox(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new RepositoryModel());
            builder.RegisterModule(new RestModule(Configuration));
        }
    }
}
