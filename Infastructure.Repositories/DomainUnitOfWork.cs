using Core.Interfaces.Interfaces.IData;
using Domain.Interfaces.IData;
using Infastructure.Data.Persistence;

namespace Infastructure.Repositories
{
    public class DomainUnitOfWork<T> : IUnitOfWork<T>, IDisposable where T : class
    {
        readonly IDbContext DomainDbContext;
        private bool disposedValue;

        IRepository<T>? Repository { get; set; }
        public DomainUnitOfWork(IDbContext domainDbContext, IRepository<T> repository)
        {
            Repository = repository;
            DomainDbContext = domainDbContext;
            Repository.DbContext = domainDbContext;
        }

        public IRepository<T> GetRepository()
        {
            return Repository;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DomainDbContext.Dispose();
                    Repository = null;
                }

                disposedValue = true;
            }
        }

        ~DomainUnitOfWork() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
