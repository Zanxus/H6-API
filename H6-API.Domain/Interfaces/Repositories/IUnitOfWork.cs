using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ITrackedMediaRepository TrackedMediaRepository { get; }
        IOMDBSearchMediaRepository SearchMediaRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
