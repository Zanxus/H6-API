using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace H6_API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AssignUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task<ApplicationUser?> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        async Task<IdentityResult> IUserService.UpdateUserAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        async Task<IdentityResult> IUserService.DeleteUserAsync(string id)
        {
            ApplicationUser usertoDelete = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(usertoDelete);
        }

        Task<IEnumerable<ApplicationUser>> IUserService.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
