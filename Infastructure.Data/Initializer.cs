
using Core.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.Data
{
    public class Initializer : IDbStartup
    {
        public string KeyName { get => "BtcUsdDbConn"; set => _ = value; }
        public void AddDbContext(IServiceCollection services, string connectionString) =>
              services.AddDbContext<DomainDbContext>(options => options.UseSqlite(connectionString));
    }
}
