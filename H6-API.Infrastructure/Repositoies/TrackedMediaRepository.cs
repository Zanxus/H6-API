using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Infrastructure.Repositoies
{
    public class TrackedMediaRepository : RepositoryBase<TrackedMedia>, ITrackedMediaRepository
    {
        public TrackedMediaRepository(WatchMateDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<TrackedMedia>> GetAllByUserIdAsync(string userId)
        {
            return await _dbSet.Where(m => m.ApplicationUser.Id == userId).ToListAsync();
        }

        public async Task<TrackedMedia?> GetByImdbIdAsync(string imdbId)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.ImdbId == imdbId);
        }

        public async Task<int> GetCountByStateAsync(TrackedState state)
        {
            return await _dbSet.CountAsync(m => m.TrackedState == state);
        }

        // Implement any additional methods specific to TrackedMedia here
    }

}
