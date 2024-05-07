using FreeCheck.BusinessLogic;
using FreeCheck.DTO.Common;
using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Helper;
using FreeCheck.Repository.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeCheck.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoeController : ControllerBase
    {
        public ILogic<GetListShoeCheckParam, GetListShoeCheckResult> _getListShoeCheckLogic;
        public ILogger<ShoeController> _logger;
        public ShoeController(ILogic<GetListShoeCheckParam, GetListShoeCheckResult> getListShoeCheckLogic, ILogger<ShoeController> logger)
        {
            _getListShoeCheckLogic = getListShoeCheckLogic;
            _logger = logger;
        }

        [HttpGet("Shoes-Authen"), Authorize(Roles = "Admin")]
        public ActionResult<ShoeCheck> GetListShoeCheckAuthen()
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

        [HttpGet("Shoes")]
        public ResponseResultData<GetListShoeCheckResult?> GetListShoeCheck([FromQuery] GetListShoeCheckParam param)
        {
            _logger.LogInformation("Execute: GetListShoeCheck {param} ", param);
            var resultData = _getListShoeCheckLogic.Execute(param);

            if (resultData?.Result == true)
            {
                return ResponseHelper<GetListShoeCheckResult>.ResOK(resultData);
            }
            else
            {
                return ResponseHelper<GetListShoeCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData.Code, Desc = resultData.Desc } });
            }
        }
    }
}