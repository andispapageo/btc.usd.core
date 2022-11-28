using Autofac;

namespace Domain.Interfaces
{
    public interface IDependencyRegister
    {
        void Register(ContainerBuilder containerBuilder);
    }
}
