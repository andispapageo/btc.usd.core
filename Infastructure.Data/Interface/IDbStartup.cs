using Microsoft.Extensions.DependencyInjection;

namespace Domain.Interfaces
{
    public interface IDbStartup
    {
        void AddDbContext(IServiceCollection services, string connectionString);
        string KeyName { get; set; }
    }
}
