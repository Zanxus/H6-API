using H6_API.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<ApplicationUser?> FindByNameAsync(string username);
    }
}
