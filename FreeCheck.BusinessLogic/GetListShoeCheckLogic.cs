using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic
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
                var resultData = new GetListShoeCheckResult()
                {
                    Data = new List<GetListShoeResult>(),
                    Pagination = new PaginationResult(),
                    Result = false,
                    Code = "FAIL",
                };

                resultData.Data = _shoeCheckReposity.GetListShoeCheck(param);

                //resultData.Data.Add(new GetListShoeResult
                //{
                //    Id = Guid.NewGuid(),
                //    Code = "",
                //    Name = "Air Jordan"
                //});



                resultData.Result = true;

                return resultData;
            }
            catch (Exception ex)
            {
                return new GetListShoeCheckResult
                {
                    Result = false,
                    Code = "GET_LIST_SHOE_CHECK_FAIL",
                    Desc = ex.Message
                };
            }
        }
    }
}
