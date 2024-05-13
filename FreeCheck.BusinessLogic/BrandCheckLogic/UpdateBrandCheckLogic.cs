using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.BrandCheckLogic
{
    public class UpdateBrandCheckLogic : ILogic<UpdateBrandCheckParam, UpdateBrandCheckResult>
    {
        public UpdateBrandCheckLogic() { }
        public UpdateBrandCheckResult Execute(UpdateBrandCheckParam param)
        {
            return new UpdateBrandCheckResult { };
        }
    }
}
