using FreeCheck.BusinessLogic;
using FreeCheck.DTO.Common;
using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Gateway.Middlewares;
using FreeCheck.Helper;
using FreeCheck.Repository.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FreeCheck.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(AuthorizeUserAttribute))]
    public class ShoeController : ControllerBase
    {
        public ILogic<GetListShoeCheckParam, GetListShoeCheckResult> _getListShoeCheckLogic;
        public ShoeController(ILogic<GetListShoeCheckParam, GetListShoeCheckResult> getListShoeCheckLogic)
        {
            _getListShoeCheckLogic = getListShoeCheckLogic;
        }

        [HttpGet("Shoes")]
        public ResponseResultData<GetListShoeCheckResult?> GetListShoeCheck([FromQuery] GetListShoeCheckParam param)
        {
            Log.Information("Start GetListShoeCheck {@param}", param);
            var resultData = _getListShoeCheckLogic.Execute(param);

            if (resultData?.Result == true)
            {
                Log.Information($"End GetListShoeCheck {resultData.Data}");
                return ResponseHelper<GetListShoeCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End GetListShoeCheck {resultData?.Desc}");
                return ResponseHelper<GetListShoeCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData.Code, Desc = resultData.Desc } });
            }
        }
    }
}