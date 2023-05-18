namespace PDWA5.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(int id);
        IEnumerable<TEntity> Get();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void DeleteById(int id);
    }
}
