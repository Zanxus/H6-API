using H6_API.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetUserByNameAsync(string username);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> AssignUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<ApplicationUser?> GetUserById(string id);

    }
}
