using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCheck.DTO.Results;

namespace FreeCheck.Helper.JwtToken
{
    public interface IJwtToken
    {
        AuthTokenUserResult GenerateJwtToken();
        AuthTokenUserResult? VerifyToken(string token);
    }
}
