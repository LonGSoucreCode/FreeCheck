using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic.BrandCheckLogic
{
    public class DeleteBrandCheckLogic : ILogic<DeleteBrandCheckParam, DeleteBrandCheckResult>
    {
        public DeleteBrandCheckLogic() { }  
        public DeleteBrandCheckResult Execute (DeleteBrandCheckParam param)
        {
            return new DeleteBrandCheckResult { };
        }
    }
}
