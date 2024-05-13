using FreeCheck.DTO.Params;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using Serilog;
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
        private FakeDataBrandCheck fakeData = new FakeDataBrandCheck();
        public BrandCheckRepository(FreeCheckDbContext freeCheckDbContext)
        {
            _freeCheckDbContext = freeCheckDbContext;
        }
        public GetListBrandCheckResult? GetListBrandCheck(GetListBrandCheckParam param)
        {
            Log.Information("Repository GetListBrandCheck {@param}", param);
            //var query = _freeCheckDbContext.BrandChecks.Where(s => s.IsDeleted != false)
            //        .Skip((param.Page - 1) * param.PageSize)
            //        .Take(param.PageSize)
            //        .ToList().Select(s => new GetListBrandResultData()
            //        {
            //            Id = s.Id,
            //            Name = s.Name,
            //            ImageUrl = s.ImageUrl,
            //        }).ToList();

            var query = fakeData.BrandChecks
                    .Skip((param.Page - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToList().Select(s => new GetListBrandResultData()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ImageUrl = s.ImageUrl,
                    }).ToList();

            return null;
        }
    }
    public class FakeDataBrandCheck
    {
        public List<BrandCheck> BrandChecks { get; set; }
        public List<string> fakeID = new List<string>()
        {
            "7ad1ccfc-2aa8-487b-b621-5959f0151fb4",
            "d65d5873-525f-4a38-9561-205be902e351"
        };
        public List<string> fakeImage = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/en/thumb/3/37/Jumpman_logo.svg/1200px-Jumpman_logo.svg.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToiv0dnUSX_V8NG7-d2uONa0rvAADRUGGmQ1FrsBsMisHVN7J-t6K5rhyhUA&s"
        };
        public FakeDataBrandCheck()
        {
            for (int i = 0; i < 2; i++)
            {
                BrandChecks?.Add(new BrandCheck()
                {
                    Id = Guid.Parse(fakeID[i]),
                    Name = "Air Jordan",
                    ImageUrl = fakeImage[i],
                });
            }
        }
    }
}
