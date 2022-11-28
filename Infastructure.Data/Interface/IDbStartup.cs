using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    public interface IDbStartup
    {
        void AddDbContext(IServiceCollection services, string connectionString);
        string KeyName { get; set; }
    }
}
