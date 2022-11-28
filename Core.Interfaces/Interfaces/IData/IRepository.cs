using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Interfaces.Interfaces.IData
{
    public interface IRepository<T> where T : class
    {
        DbContext DbContext { get; set; }
        IEnumerable<T> GetCollection(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
        IEnumerable<T> GetQuery(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
        Task<T?> GetByID(object id);
    }
}
