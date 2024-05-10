using FreeCheck.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Params
{
    public class GetListBrandCheckResult : IResult
    {
        public List<GetListBrandResultData> Data { get; set; } = new List<GetListBrandResultData>();
    }
    public class GetListBrandResultData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";

    }
}
