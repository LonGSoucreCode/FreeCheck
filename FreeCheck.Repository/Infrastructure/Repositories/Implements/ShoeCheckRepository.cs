using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using Serilog;
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
        private FakeData fakeData = new FakeData();
        public ShoeCheckRepository(FreeCheckDbContext freeCheckDbContext)
        {
            _freeCheckDbContext = freeCheckDbContext;
        }
        public GetListShoeCheckResult GetListShoeCheck(GetListShoeCheckParam param)
        {
            Log.Information("Repository GetListShoeCheck {param}", param);
            //var resultData = _freeCheckDbContext.ShoeCheck.Where(s => s.IsDeleted != false).OrderByDescending(o => o.CreationTime)
            //        .Skip((param.Page - 1) * param.PageSize)
            //        .Take(param.PageSize)
            //        .ToList().Select(s => new GetListShoeResult()
            //        {
            //            Id = s.Id,
            //            Code = s.Code,
            //            Name = s.Name,
            //            StatusChecker = s.StatusChecker,
            //            CheckDateTime = s.CheckDateTime
            //        }).ToList();

            var resultData = new GetListShoeCheckResult();

            var query = fakeData.FakeDataShoe.OrderBy(o => o.CheckDateTime);

            resultData.Data = query.Skip((param.Page - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToList().Select(s => new GetListShoeResult()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        StatusChecker = s.StatusChecker,
                        CheckDateTime = s.CheckDateTime,
                        ShoeBrand = s.ShoeBrand,
                        ShoeImages = s.ShoeImages,
                    }).ToList();

            var total = query.Count();

            resultData.Pagination = new PaginationResult
            {
                PageSize = param.PageSize,
                Page = param.Page,
                Total = total,
                TotalPage = (int)Math.Ceiling(total / (double)param.PageSize)
            };
            return resultData;
        }
    }

    public class FakeData
    {
        public Guid brandId = Guid.NewGuid();
        public List<GetListShoeResult> FakeDataShoe = new List<GetListShoeResult>();

        public FakeData()
        {
            var Images = new GetListShoeImageResult
            {
                Id = Guid.NewGuid(),
                ImageData = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2K9VlgAvagRV8ODYCdlPt6O4ddRTkKPnKpg&s"
            };

            for (int i = 1; i <= 37; i++)
            {
                FakeDataShoe.Add(new GetListShoeResult()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Air Jordan {i}",
                    StatusChecker = (i % 2 != 0) ? true : false,
                    CheckDateTime = DateTime.Now,
                    ShoeBrand = new GetListShoeBrandResult
                    {
                        Id = brandId,
                        Name = "Air Jordan",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/3/37/Jumpman_logo.svg/1200px-Jumpman_logo.svg.png"
                    },
                    ShoeImages = Images,
                });
            }
        }


    }
}
