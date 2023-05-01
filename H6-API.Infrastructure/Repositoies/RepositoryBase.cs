using H6_API.Domain.Interfaces.Repositories;
using H6_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace H6_API.Infrastructure.Repositoies
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal readonly WatchMateDbContext _dbContext;
        internal readonly DbSet<T> _dbSet;
        public RepositoryBase(WatchMateDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public T? Get(Guid id)
        {
            return _dbSet.Find(id);
        }
        public IReadOnlyList<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
