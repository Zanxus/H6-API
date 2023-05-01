using H6_API.Domain.Entites;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<ApplicationUser?> FindByNameAsync(string username);
    }
}
