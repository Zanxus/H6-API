using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace H6_API.Infrastructure.Repositoies
{
    public class UserRepository : IUserRepository
    {
        private readonly WatchMateDbContext _dbContext;

        public UserRepository(WatchMateDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id.ToString());
        }

        public async Task AddAsync(ApplicationUser entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IReadOnlyList<ApplicationUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public ApplicationUser? Get(int id)
        {
            return _dbContext.Users.Find(id.ToString());
        }

        public void Add(ApplicationUser entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(ApplicationUser entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ApplicationUser entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<ApplicationUser?> FindByNameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
