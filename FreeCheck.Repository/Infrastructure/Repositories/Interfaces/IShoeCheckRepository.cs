using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Repositories.Interfaces
{
    public interface IShoeCheckRepository
    {
        public List<GetListShoeResult> GetListShoeCheck(GetListShoeCheckParam param);
    }
}
