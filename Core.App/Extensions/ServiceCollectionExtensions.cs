using Core.App.Engine;
using Core.App.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Core.App.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEngine ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            IEngine engine = EngineContext.Create();
            engine.ConfigureServices(services, configuration);
            return engine;
        }
    }
}
