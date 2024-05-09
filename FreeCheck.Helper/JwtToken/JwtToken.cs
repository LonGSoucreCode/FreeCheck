using FreeCheck.DTO.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Helper.JwtToken
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _configuration;
        public JwtToken(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public AuthTokenUserResult GenerateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("role", "User")
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refeshTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                            new Claim("role", "User"),
                            new Claim("expires", new DateTimeOffset(tokenDescriptor.Expires.Value).ToUnixTimeSeconds().ToString())
                        }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var refeshToken = tokenHandler.CreateToken(refeshTokenDescriptor);

            return new AuthTokenUserResult
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = tokenHandler.WriteToken(refeshToken),
                Expires = new DateTimeOffset(tokenDescriptor.Expires.Value).ToUnixTimeSeconds(), // token will expire after 24 hours unit by second
                //Id = id,
                Role = "User",
                Result = token != null && refeshToken != null ? true : false,
            };
        }
        public AuthTokenUserResult? VerifyToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value!);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role");
                return new AuthTokenUserResult
                {
                    AccessToken = token,
                    Id = id != null ? id.Value : "",
                    Role = role != null ? role.Value : ""
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
