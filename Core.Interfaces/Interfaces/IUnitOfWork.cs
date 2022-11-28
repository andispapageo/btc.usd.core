namespace Core.Interfaces.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> GetRepository();
    }
}
