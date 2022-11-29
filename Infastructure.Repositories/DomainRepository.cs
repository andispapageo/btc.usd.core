using Core.Interfaces.Interfaces.IData;
using Domain.Interfaces.IData;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infastructure.Repositories
{
    public class DomainRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
      
        public IDbContext DbContext { get; set; }
        public DbSet<TEntity> DbSet { get; set ; }

        public virtual IEnumerable<TEntity> GetCollection(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null) query = query.Where(filter);
            foreach (var incProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(incProp);

            if (orderBy != null) return orderBy(query).ToList();
            else return query.ToList();
        }

        public virtual IEnumerable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
          
            IQueryable<TEntity> query = DbSet;
            if (filter != null) query = query.Where(filter);
            foreach (var incProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(incProp);

            if (orderBy != null) return orderBy(query);
            else return query;
        }

        public virtual async Task<TEntity?> GetByID(object id)
        {
            if (DbSet == null) return null;
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<int> InsertOrUpdate(TEntity entity)
        {
            var id = ((dynamic)entity).Id;
            if (id != null && id != default(int))
            {
                var entityDb = await GetByID(id);
                if (entityDb != null)
                {
                    ((DbContext)DbContext).Entry<TEntity>(entityDb).State = EntityState.Detached;
                    Update(entity);
                }
            }
            else
            {
                await Insert(entity);
            }
            return await ((DbContext)DbContext).SaveChangesAsync();
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (((DbContext)DbContext).Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            var entry = ((DbContext)DbContext).Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
