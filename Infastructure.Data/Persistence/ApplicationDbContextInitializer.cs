
using Domain.Interfaces;
using Domain.Interfaces.IData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.Data.Persistence
{
    public class ApplicationDbContextInitializer : IDbStartup
    {
        public string KeyName { get => "BtcUsdDbConn"; set => _ = value; }
        public void AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Transient);
            services.AddScoped<IDbContext>(provider => provider.GetService<ApplicationDbContext>());

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dataContext.Database.EnsureCreated();
                dataContext.Database.Migrate();
            }
        }
    }
}
