using FreeCheck.DTO.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.BrandCheckLogic
{
    public class GetListBrandCheck : ILogic<GetListBrandCheckParam, GetListBrandCheckResult>
    {
        public GetListBrandCheckResult Execute(GetListBrandCheckParam param)
        {
            return new GetListBrandCheckResult { };
        }
    }
}
