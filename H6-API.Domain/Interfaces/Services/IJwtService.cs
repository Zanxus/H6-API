using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        SecurityToken GenerateJwtToken(IEnumerable<Claim> claims);
    }
}
