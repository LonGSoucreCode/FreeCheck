using FreeCheck.Helper.JwtToken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FreeCheck.Gateway.Middlewares
{
    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IJwtToken _jwtToken;
        public AuthorizeUserAttribute(IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            var user = _jwtToken.VerifyToken(token);

            if (//string.IsNullOrEmpty(user?.Id) ||
                user?.Role?.ToUpper() != "USER")

            {
                // not logged in
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            //Get User
            //var userDetail = _getUserLogic.Execute(new GetUserParam
            //{
            //    Id = user?.Id != null ? Guid.Parse(user.Id) : Guid.Empty,
            //});

            //if (userDetail?.Result == false)
            //{
            //    // not logged in
            //    context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //    return;
            //}

            //Set context
            context.HttpContext.Items["User"] = new
            {
                UserId = //Guid.Parse(user.Id),
                Guid.NewGuid().ToString(),
                Code = "userDetail.Data.Code",
                Result = 1,

            };
        }
    }
}
