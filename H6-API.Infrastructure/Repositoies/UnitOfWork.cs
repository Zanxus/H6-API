using H6_API.Domain.Interfaces.Repositories;
using H6_API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Infrastructure.Repositoies
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WatchMateDbContext _dbContext;

        public UnitOfWork(WatchMateDbContext dbContext, IOMDBSearchMediaRepository searchMediaRepository,ITrackedMediaRepository trackedMediaRepository, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            TrackedMediaRepository = trackedMediaRepository;
            SearchMediaRepository = searchMediaRepository;
        }

        public ITrackedMediaRepository TrackedMediaRepository { get; }
        public IOMDBSearchMediaRepository SearchMediaRepository { get; }
        public  IUserRepository UserRepository { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
