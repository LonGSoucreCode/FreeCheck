using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.ShoeCheckLogic
{
    public class GetDetailShoeCheckLogic : ILogic<GetDetailShoeCheckParam, GetDetailShoeCheckResult>
    {
        public IShoeCheckRepository _shoeCheckReposity;
        public GetDetailShoeCheckLogic(IShoeCheckRepository shoeCheckReposity)
        {
            _shoeCheckReposity = shoeCheckReposity;
        }

        public GetDetailShoeCheckResult Execute(GetDetailShoeCheckParam param) 
        {
            try
            {
                Log.Information("Execute Logic GetDetailShoeCheck {@param}", param);

                var resultData = new GetDetailShoeCheckResult()
                {
                    Data = new GetDetailShoeResultData(),
                    Result = false,
                    Code = "FAIL",
                };

                var shoeCheck = _shoeCheckReposity.GetDetailShoeCheck(param);

                if (shoeCheck == null)
                {
                    return new GetDetailShoeCheckResult
                    {
                        Data = null,
                        Result = false,
                        Code = "FAIL",
                        Desc = "SHOE CHECK NOT FOUND",
                    };
                }

                resultData.Data = _shoeCheckReposity.GetDetailShoeCheck(param);
                resultData.Result = true;
                resultData.Code = "SUCCES";
                return resultData;
            }
            catch (Exception ex)
            {
                Log.Error($"Execute Logic GetDetailShoeCheck Error {ex.Message}");
                return new GetDetailShoeCheckResult
                {
                    Result = false,
                    Code = "GET_DETAIL_SHOE_CHECK_ERROR",
                    Desc = ex.Message
                };
            }
        }
    }
}
