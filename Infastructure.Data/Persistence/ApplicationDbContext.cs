using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;
using Domain.Interfaces.IData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infastructure.Data.Persistence
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<TbBitStamp> BitStampModels { get; set; }
        public DbSet<TbBitFinex> BitFinexModels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
