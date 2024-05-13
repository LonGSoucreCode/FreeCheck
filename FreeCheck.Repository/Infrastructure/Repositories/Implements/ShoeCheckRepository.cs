using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Entity;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Repositories.Implements
{
    public class ShoeCheckRepository : IShoeCheckRepository
    {
        private readonly FreeCheckDbContext _freeCheckDbContext;
        private FakeDataShoeCheck fakeData = new FakeDataShoeCheck();
        public ShoeCheckRepository(FreeCheckDbContext freeCheckDbContext)
        {
            _freeCheckDbContext = freeCheckDbContext;
        }

        public GetListShoeCheckResult? GetListShoeCheck(GetListShoeCheckParam param)
        {
            Log.Information("Repository GetListShoeCheck {@param}", param);
            //var query = _freeCheckDbContext.ShoeCheck.Where(s => s.IsDeleted != false).OrderByDescending(o => o.CreationTime)
            //        .Skip((param.Page - 1) * param.PageSize)
            //        .Take(param.PageSize)
            //        .ToList().Select(s => new GetListShoeResultData()
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
                    .ToList().Select(s => new GetListShoeResultData()
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

        public GetDetailShoeResultData? GetDetailShoeCheck(GetDetailShoeCheckParam param)
        {
            Log.Information("Repository GetDetailShoeCheck {@param}", param);

            var resultData = new GetDetailShoeResultData();

            var shoeCheck = fakeData.FakeDataShoe.FirstOrDefault(o => o.Id == param.Id);

            if (shoeCheck == null)
            {
                return null;
            }

            resultData = new GetDetailShoeResultData
            {
                Id = shoeCheck.Id,
                Code = shoeCheck.Code,
                Name = shoeCheck.Name,
                StatusChecker = shoeCheck.StatusChecker,
                CheckDateTime = shoeCheck.CheckDateTime,
                ShoeBrand = new GetDetailShoeBrandResult
                {
                    Id = shoeCheck.ShoeBrand.Id,
                    Name = shoeCheck.ShoeBrand.Name,
                    ImageUrl = shoeCheck.ShoeBrand.ImageUrl
                },
                ShoeImages = new List<GetDetailShoeImageResult>()
            };
            for (int i = 0; i <= 3; i++)
            {
                resultData.ShoeImages.Add(new GetDetailShoeImageResult
                {
                    Id = shoeCheck.Id,
                    ImageData = shoeCheck.ShoeImages.ImageData
                });
            }

            return resultData;
        }
    }

    public class FakeDataShoeCheck
    {
        public Guid brandId = Guid.NewGuid();
        public List<GetListShoeResultData> FakeDataShoe = new List<GetListShoeResultData>();
        public List<string> fakeID = new List<string>()
        {
            "0b925687-d837-4425-84a6-3f0486dea32b",
            "d7a17112-1c1c-4c55-988e-e6ed585fb64d",
            "43461b71-bfec-4e08-831d-9a7aa2949a66",
            "58ac3385-f4c2-4a47-bedc-bc17460415cb",
            "2c1fe125-7238-4a8b-8208-ef24669cfcea",
            "76dcc72e-2f48-4b38-a551-e38b322d6f1c",
            "48e8fa43-66ac-465c-8758-5b1a767b9c5d",
            "571377ee-01de-462e-921f-d351880aaf97",
            "46834e49-0977-4e65-9f4c-ccd894beb714",
            "72cc46eb-7076-4913-8695-2904bfb40e42",
            "03e71dfa-57bf-4a46-bc2a-7d1c01e3a941",
            "95a29a13-e38e-49c4-a5c2-654bd7269abb",
            "6d08325f-818b-4147-b032-3ffa94ede57b",
            "9dc70bc0-f966-402f-bbf5-55539f92c3c3",
            "b43b8687-7ad7-4312-bf28-f0cf750afba0",
            "7c6deca8-f531-4c82-a683-dfd543c3dc5d",
            "7de0f576-a24d-4f44-b771-3fd4364b71b7",
            "66d1055f-847a-42ce-9e90-3286c1266bde",
            "1ee0f1a5-fd00-4dd3-a21c-3edc7e00b8a2",
            "2ee7d383-c2aa-4cfb-aef6-0235e011686e",
            "0b0f4fba-a17e-432b-b02d-e311063a70b1",
            "d52ce319-24b2-4602-bf3a-465890fcdfa5",
            "0ed47b8d-0e4a-4abd-8037-42a98e7a2d5e",
            "a20b8731-4227-49b3-ab6b-4b970ed7377e",
            "dc346f87-bb90-4b65-b5b1-8f5897e0e543",
            "bd35f53f-2465-409f-879e-4923f084dbd9",
            "c0ca524b-923a-40af-b3ea-22e728479df7",
            "e6790dbe-1557-4880-b7ad-d0f2379cf9a1",
            "6af6c110-5272-4f1c-96b8-4767ad3a5d32",
            "8688dcf1-c579-4a94-934a-92b373248c20",
            "7e3e600a-1d79-4734-b44a-e42d415e6446",
            "5bc3d073-fdcc-4ced-ab38-777a3c31fe4e",
            "022d575c-3fd6-4a09-9b09-e4c183ee100e",
            "e60475eb-1d6f-4832-9eb3-11fdc7bb6aa6",
            "3e5a7995-17f6-4428-9e3c-4ee7a02bc79e",
            "693a0280-72de-4ca6-9f60-e07a88922383",
            "a0aa7d1d-7acd-4177-bfa1-ecc42f007e4c"
        };

        public FakeDataShoeCheck()
        {
            var Images = new GetListShoeImageResult
            {
                Id = Guid.NewGuid(),
                ImageData = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2K9VlgAvagRV8ODYCdlPt6O4ddRTkKPnKpg&s"
            };

            for (int i = 1; i <= 37; i++)
            {
                FakeDataShoe.Add(new GetListShoeResultData()
                {
                    Id = Guid.Parse(fakeID[i-1]),
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
