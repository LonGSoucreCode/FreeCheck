using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Repositories.Interfaces
{
    public interface IBrandCheckRepository
    {
        public GetListBrandCheckResult? GetListShoeCheck(GetListBrandCheckParam param);
    }
}
