using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Helper.JwtToken;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.AuthenticateLogic
{
    public class LoginLogic : ILogic<LoginParam, LoginResult>
    {
        public IJwtToken _jwtToken;
        public LoginLogic(IJwtToken jwtToken) 
        {
            _jwtToken = jwtToken;   
        }
        public LoginResult Execute(LoginParam param)
        {
            try
            {
                var token = _jwtToken.GenerateJwtToken();

                var resultData = new LoginResult()
                {
                    Result = true,
                    Data = new LoginResultData()
                    {
                        AccessToken = token.AccessToken,
                        RefreshToken = token.RefreshToken,
                    },
                };

                return resultData;
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Result = false,
                    Code = "LOGIN_FAIL",
                    Desc = ex.Message
                };
            }
        }
    }
}
