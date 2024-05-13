using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using FreeCheck.DTO.Results;
using FreeCheck.BusinessLogic;
using FreeCheck.DTO.Params;

namespace FreeCheck.Gateway.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticateController : Controller
    {

        public LoginResult User { get; set; }

        public readonly IConfiguration _configuration;
        public ILogic<LoginParam, LoginResult> _loginLogic;
        public AuthenticateController(IConfiguration configuration, ILogic<LoginParam, LoginResult> loginLogic)
        {
            _configuration = configuration;
            _loginLogic = loginLogic;
        }

        //[HttpPost("Register")]
        //public ActionResult<User> Register(UserParam request)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        //    user.PasswordHash = passwordHash;
        //    user.UserName = request.UserName;

        //    return Ok(user);
        //}

        [HttpPost("login")]
        public LoginResult Login(LoginParam param)
        {
            var resultData = _loginLogic.Execute(param);

            return resultData;
        }

        //[HttpPost("Check")]
        //public LoginResult Check(LoginParam param)
        //{
        //    if()

        //    return resultData;
        //}
    }
}
