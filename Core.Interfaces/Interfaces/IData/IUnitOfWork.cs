namespace Core.Interfaces.Interfaces.IData
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> GetRepository();
    }
}
