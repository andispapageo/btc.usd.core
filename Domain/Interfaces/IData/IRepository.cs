using Domain.Interfaces.IData;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Interfaces.Interfaces.IData
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IDbContext DbContext { get; set; }
        DbSet<TEntity> DbSet { get; set; }
        IEnumerable<TEntity> GetCollection(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        Task<int> InsertOrUpdate(TEntity entity);
        Task<TEntity?> GetByID(object id);
    }
}
