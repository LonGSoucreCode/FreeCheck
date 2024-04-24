using FreeCheck.Repository.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeCheck.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoeController : ControllerBase
    {
        [HttpGet("Shoes"), Authorize(Roles = "Admin")]
        public ActionResult<ShoeCheck> GetListShoe()
        {
            var result = new List<ShoeCheck>();

            result.Add(new ShoeCheck
            {
                Id = Guid.NewGuid(),
                Code = "",
                Name = "Air Jordan"

            });

            return Ok(result);
        }
    }
}