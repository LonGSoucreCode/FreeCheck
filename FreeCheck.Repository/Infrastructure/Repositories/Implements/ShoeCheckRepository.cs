using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Repositories.Implements
{
    public class ShoeCheckRepository : IShoeCheckRepository
    {
        private readonly FreeCheckDbContext _freeCheckDbContext;
        public ShoeCheckRepository(FreeCheckDbContext freeCheckDbContext)
        {
            _freeCheckDbContext = freeCheckDbContext;
        }
        public List<GetListShoeResult> GetListShoeCheck(GetListShoeCheckParam param)
        {
            var resultData = _freeCheckDbContext.ShoeCheck.Where(s => s.IsDeleted != false).OrderByDescending(o => o.CreationTime)
                    .Skip((param.Page - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToList().Select(s => new GetListShoeResult()
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name,
                        StatusChecker = s.StatusChecker,
                        CheckDateTime = s.CheckDateTime
                    }).ToList();

            return resultData;
        }
    }
}
