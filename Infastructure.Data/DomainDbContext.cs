using Core.App.Entities.BitFinex;
using Core.App.Entities.BitStamp;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infastructure.Data
{
    public class DomainDbContext : DbContext
    {
        public DbSet<TbBitStamp> BitStampModels { get; set; }    
        public DbSet<TbBitFinex> BitFinexModels { get; set; }    
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
