using Autofac;
using Core.App.Interfaces;
using Domain.TypeFinder;
using Core.Mapping;
using Domain.Interfaces;
using System.Reflection;
using Infastructure.Rest.Interface;
using Domain.Configuration;

namespace Core.App.Engine
{
    public class EngineCore : IEngine
    {
        #region Properties

        public ITypeFinder? TypeFinder => _typeFinder;
        private ITypeFinder? _typeFinder { get; set; }
        public virtual IServiceProvider? ServiceProvider => _serviceProvider;
        private IServiceProvider? _serviceProvider { get; set; }

        #endregion

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            _typeFinder = new AppTypeFinder();
            AddAutoMapper(services);

            //dbContext Configurations reflection
            RegisterDatabases(services, configuration);
            //restApi Congigurations reflection
            RegisterRestApis(services, configuration);
            ConfigureSettings(services, configuration);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GLobalConfig>(opt =>
           {
               opt.Sources = configuration.GetSection("Sources")?.AsEnumerable() ?? default;
           });
        }

        public void RegisterDatabases(IServiceCollection services, IConfiguration configuration)
        {

            IEnumerable<Type> dbRegisters = _typeFinder?.FindClassesOfType<IDbStartup>() ?? new Type[] { };
            var instances = dbRegisters.Select(dbRegisters => Activator.CreateInstance(dbRegisters) as IDbStartup);

            foreach (var dbS in instances.Where(x => x != null))
                dbS?.AddDbContext(services, configuration.GetConnectionString(dbS.KeyName) ?? string.Empty);
        }

        public void RegisterRestApis(IServiceCollection services, IConfiguration configuration)
        {

            IEnumerable<Type> dbRegisters = _typeFinder?.FindClassesOfType<IRestService>() ?? new Type[] { };
            var instances = dbRegisters.Select(dbRegisters => Activator.CreateInstance(dbRegisters) as IRestService);

            foreach (var dbS in instances.Where(x => x != null))
            { }
        }

        public void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();
            containerBuilder.RegisterInstance(_typeFinder).As<ITypeFinder>().SingleInstance();
            _typeFinder.FindClassesOfType<IDependencyRegister>()
                .Select(di => Activator.CreateInstance(di) as IDependencyRegister)
                .AsParallel().ForAll(di => di.Register(containerBuilder));
        }

        private void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(MappingAssemblyMarker.Marker);
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
                return assembly;

            var tf = Resolve<ITypeFinder>();
            if (tf == null) return null;
            assembly = tf.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            return assembly;
        }
        protected IServiceProvider GetServiceProvider()
        {
            if (ServiceProvider == null) return null;
            var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
            var context = accessor?.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            var sp = GetServiceProvider();
            if (sp == null)
                return null;
            return sp.GetService(type);
        }

        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

       
    }
}
