using FreeCheck.DTO.Params;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Repositories.Implements
{
    public class BrandCheckRepository : IBrandCheckRepository
    {
        private readonly FreeCheckDbContext _freeCheckDbContext;
        public GetListBrandCheckResult? GetListShoeCheck(GetListBrandCheckParam param)
        {
            
        }
    }
}
