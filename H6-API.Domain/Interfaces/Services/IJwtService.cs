using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        JwtSecurityToken GetToken(List<Claim> claims);
    }
}
