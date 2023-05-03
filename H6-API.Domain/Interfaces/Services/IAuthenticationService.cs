using H6_API.Domain.Entites;
using H6_API.Domain.Models;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(LoginModel model);
        Task<string> Register(RegisterModel model);
        Task<string> RegisterAdmin(RegisterModel model);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}
