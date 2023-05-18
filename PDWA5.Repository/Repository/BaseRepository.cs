using Microsoft.EntityFrameworkCore;
using PDWA5.Data.Context;
using PDWA5.Domain.Interface.Repository;

namespace PDWA5.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ReviewContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ReviewContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            entity = _dbSet.Add(entity).Entity;
            _context.SaveChanges();
            return entity;
        }


        public void DeleteById(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity!);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get() => _dbSet.ToList();

        public T? GetById(int id) => _dbSet.Find(id);

        public T Update(T entity)
        {
            entity = _dbSet.Update(entity).Entity;
            _context.SaveChanges();
            return entity;
        }
    }
}
