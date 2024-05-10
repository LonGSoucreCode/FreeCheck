using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.GhoeCheckLogic
{
    public class GetListShoeCheckLogic : ILogic<GetListShoeCheckParam, GetListShoeCheckResult>
    {
        public IShoeCheckRepository _shoeCheckReposity;
        public GetListShoeCheckLogic(IShoeCheckRepository shoeCheckReposity)
        {
            _shoeCheckReposity = shoeCheckReposity;
        }
        public GetListShoeCheckResult Execute(GetListShoeCheckParam param)
        {
            try
            {
                Log.Information("Execute Logic GetListShoeCheck {@param}", param);
                var resultData = new GetListShoeCheckResult()
                {
                    Data = new List<GetListShoeResultData>(),
                    Pagination = new PaginationResult(),
                    Result = false,
                    Code = "FAIL",
                };

                resultData = _shoeCheckReposity.GetListShoeCheck(param);
                resultData.Result = true;
                resultData.Code = "SUCCES";
                return resultData;
            }
            catch (Exception ex)
            {
                Log.Error($"Execute Logic GetListShoeCheck Error {ex.Message}");
                return new GetListShoeCheckResult
                {
                    Result = false,
                    Code = "GET_LIST_SHOE_CHECK_ERROR",
                    Desc = ex.Message
                };
            }
        }
    }
}
