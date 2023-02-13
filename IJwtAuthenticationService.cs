using tpcrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace tpcrm
{
    public interface IJwtAuthenticationService
    {
        USers Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
