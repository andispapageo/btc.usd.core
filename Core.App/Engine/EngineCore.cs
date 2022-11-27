using Core.App.Interfaces;
using Core.App.TypeFinder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Core.Mapping;
using Autofac;

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
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        public void RegisterDatabases(IServiceCollection services)
        {
            IEnumerable<Type> dbRegisters = _typeFinder?.FindClassesOfType<IDbStartup>() ?? new Type[] { };
            var instances = dbRegisters
               .Select(dbRegisters => Activator.CreateInstance(dbRegisters) as IDbStartup);

            foreach (var dbS in instances.Where(x => x != null))
                dbS.AddDbContext(services, dbS.KeyName);
        }

        private void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(MappingAssemblyMarker.Marker);
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            //check for assembly already loaded
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
                return assembly;

            //get assembly from TypeFinder
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

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">Type of resolved services</typeparam>
        /// <returns>Collection of resolved services</returns>
        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        public void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
