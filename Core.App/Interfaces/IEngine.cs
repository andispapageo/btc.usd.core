using Autofac;
using global::Microsoft.Extensions.Configuration;
using global::Microsoft.Extensions.DependencyInjection;

namespace Core.App.Interfaces
{
    public interface IEngine
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>();
        void RegisterDependencies(ContainerBuilder containerBuilder);
    }
}
