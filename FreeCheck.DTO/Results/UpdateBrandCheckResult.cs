using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class UpdateBrandCheckResult : IResult
    {
        public BrandCheckResultData Data { get; set; } = new BrandCheckResultData();
    }
    public class BrandCheckResultData 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
