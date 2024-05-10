using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class GetDetailShoeCheckResult : IResult
    {
        public GetDetailShoeResultData? Data { get; set; }
    }
    public class GetDetailShoeResultData
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public bool StatusChecker { get; set; }
        public DateTime CheckDateTime { get; set; }
        public GetDetailShoeBrandResult ShoeBrand { get; set; } = new GetDetailShoeBrandResult();
        public List<GetDetailShoeImageResult> ShoeImages { get; set; } = new List<GetDetailShoeImageResult>();
    }
    public class GetDetailShoeBrandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
    public class GetDetailShoeImageResult
    {
        public Guid Id { get; set; }
        public string ImageData { get; set; } = "";
    }
}
