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
    [Route("api/shoe")]
    public class ShoeController : ControllerBase
    {
        public ILogic<GetListShoeCheckParam, GetListShoeCheckResult> _getListShoeCheckLogic;
        public ILogic<GetDetailShoeCheckParam, GetDetailShoeCheckResult> _getDetailShoeCheckLogic;
        public ShoeController(ILogic<GetListShoeCheckParam, GetListShoeCheckResult> getListShoeCheckLogic, ILogic<GetDetailShoeCheckParam, GetDetailShoeCheckResult> getDetailShoeCheckLogic)
        {
            _getListShoeCheckLogic = getListShoeCheckLogic;
            _getDetailShoeCheckLogic = getDetailShoeCheckLogic;
        }

        [HttpGet("shoes")]
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
                return ResponseHelper<GetListShoeCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }
        [HttpGet("{id}")]
        public ResponseResultData<GetDetailShoeCheckResult?> GetDetailShoeCheck(Guid id)
        {
            Log.Information("Start GetDetailShoeCheck {@id}", id);
            var resultData = _getDetailShoeCheckLogic.Execute(new GetDetailShoeCheckParam { Id = id});

            if (resultData?.Result == true)
            {
                Log.Information($"End GetDetailShoeCheck {resultData.Data}");
                return ResponseHelper<GetDetailShoeCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End GetDetailShoeCheck {resultData?.Desc}");
                return ResponseHelper<GetDetailShoeCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }

        //[TypeFilter(typeof(AuthorizeUserAttribute))]
        //[HttpGet("Shoes-Authen")]
        //public ResponseResultData<GetListShoeCheckResult?> GetListShoeCheckAuthen([FromQuery] GetListShoeCheckParam param)
        //{
        //    Log.Information("Start GetListShoeCheck {@param}", param);
        //    var resultData = _getListShoeCheckLogic.Execute(param);

        //    if (resultData?.Result == true)
        //    {
        //        Log.Information($"End GetListShoeCheck {resultData.Data}");
        //        return ResponseHelper<GetListShoeCheckResult>.ResOK(resultData);
        //    }
        //    else
        //    {
        //        Log.Error($"End GetListShoeCheck {resultData?.Desc}");
        //        return ResponseHelper<GetListShoeCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData.Code, Desc = resultData.Desc } });
        //    }
        //}
    }
}