using FreeCheck.BusinessLogic;
using FreeCheck.DTO.Common;
using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Gateway.Middlewares;
using FreeCheck.Helper;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FreeCheck.Gateway.Controllers
{
    [ApiController]
    [Route("api/brand")]
    [TypeFilter(typeof(AuthorizeUserAttribute))]
    public class BrandController : ControllerBase
    {
        public ILogic<GetListBrandCheckParam, GetListBrandCheckResult> _getListBrandLogic;
        public ILogic<UpdateBrandCheckParam, UpdateBrandCheckResult> _updateBrandLogic;
        public ILogic<DeleteBrandCheckParam, DeleteBrandCheckResult> _deleteBrandLogic;
        public BrandController(ILogic<GetListBrandCheckParam, GetListBrandCheckResult> getListBrandLogic, 
                               ILogic<UpdateBrandCheckParam, UpdateBrandCheckResult> updateBrandLogic,
                               ILogic<DeleteBrandCheckParam, DeleteBrandCheckResult> deleteBrandLogic) 
        {
            _getListBrandLogic = getListBrandLogic;
            _updateBrandLogic = updateBrandLogic;
            _deleteBrandLogic = deleteBrandLogic;
        }

        [HttpGet("brands")]
        public ResponseResultData<GetListBrandCheckResult?> GetListBrandCheck([FromQuery]GetListBrandCheckParam param)
        {
            Log.Information("Start GetListBrandCheck {@param}", param);
            var resultData = _getListBrandLogic.Execute(param);

            if (resultData?.Result == true)
            {
                Log.Information($"End GetListBrandCheck {resultData.Data}");
                return ResponseHelper<GetListBrandCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End GetListBrandCheck {resultData?.Desc}");
                return ResponseHelper<GetListBrandCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }

        [HttpPatch("{id}")]
        public ResponseResultData<UpdateBrandCheckResult?> UpdateBrandCheck([FromBody] UpdateBrandCheckParam param)
        {
            Log.Information("Start UpdateBrandCheck {@param}", param);
            var resultData = _updateBrandLogic.Execute(param);

            if (resultData?.Result == true)
            {
                Log.Information($"End UpdateBrandCheck {resultData.Data}");
                return ResponseHelper<UpdateBrandCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End UpdateBrandCheck {resultData?.Desc}");
                return ResponseHelper<UpdateBrandCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }

        [HttpDelete("{id}")]
        public ResponseResultData<DeleteBrandCheckResult?> DeleteBrandCheck(Guid id)
        {
            Log.Information("Start DeleteBrandCheck {@id}", id);
            var resultData = _deleteBrandLogic.Execute(new DeleteBrandCheckParam { Id = id});

            if (resultData?.Result == true)
            {
                Log.Information($"End DeleteBrandCheck {resultData.Data}");
                return ResponseHelper<DeleteBrandCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End DeleteBrandCheck {resultData?.Desc}");
                return ResponseHelper<DeleteBrandCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }
    }
}
