using Microsoft.Extensions.DependencyInjection;

namespace Core.App.Interfaces
{
    public interface IDbStartup
    {
        public string KeyName { get; set; }
        public void AddDbContext(IServiceCollection services, string conn);
    }
}
