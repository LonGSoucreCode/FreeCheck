﻿using FreeCheck.BusinessLogic;
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
    [Route("[controller]")]
    [TypeFilter(typeof(AuthorizeUserAttribute))]
    public class BrandController : ControllerBase
    {
        public ILogic<GetListBrandCheckParam, GetListBrandCheckResult> _getListBrandLogic;
        public ILogic<UpdateBrandCheckParam, UpdateBrandCheckResult> _updateBrandLogic;
        public BrandController(ILogic<GetListBrandCheckParam, GetListBrandCheckResult> getListBrandLogic, 
                               ILogic<UpdateBrandCheckParam, UpdateBrandCheckResult> updateBrandLogic) 
        {
            _getListBrandLogic = getListBrandLogic;
            _updateBrandLogic = updateBrandLogic;
        }

        [HttpGet("brands")]
        public ResponseResultData<GetListBrandCheckResult?> GetListBrand([FromQuery]GetListBrandCheckParam param)
        {
            Log.Information("Start GetListBrandCheck {@param}", param);
            var resultData = _getListBrandLogic.Execute(param);

            if (resultData?.Result == true)
            {
                Log.Information($"End GetDetailShoeCheck {resultData.Data}");
                return ResponseHelper<GetListBrandCheckResult>.ResOK(resultData);
            }
            else
            {
                Log.Error($"End GetDetailShoeCheck {resultData?.Desc}");
                return ResponseHelper<GetListBrandCheckResult>.ResFailed(new List<Message> { new Message { Code = resultData?.Code ?? "FAIL", Desc = resultData?.Desc ?? "FAIL" } });
            }
        }

        [HttpPatch("brand")]
        public ResponseResultData<UpdateBrandCheckResult?> UpdateDetailBrand([FromBody] UpdateBrandCheckParam param)
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

        []
    }
}
