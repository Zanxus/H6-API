using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        SecurityToken GenerateJwtToken(IEnumerable<Claim> claims);
    }
}
