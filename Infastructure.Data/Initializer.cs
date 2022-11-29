
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.Data
{
    public class Initializer : IDbStartup
    {
        public string KeyName { get => "BtcUsdDbConn"; set => _ = value; }
        public void AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DomainDbContext>(options => options.UseSqlite(connectionString));
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DomainDbContext>();
                dataContext.Database.EnsureCreated();
                dataContext.Database.Migrate();
            }
        }
    }
}
