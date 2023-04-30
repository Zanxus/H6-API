using H6_API.Domain.DTO;
using H6_API.Domain.Entites;
using H6_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
