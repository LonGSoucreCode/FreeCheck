using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class GetListShoeCheckResult : IResult
    {
        public List<GetListShoeResult>? Data { get; set; }
        public PaginationResult? Pagination { get; set; }
    }
    public class GetListShoeResult
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public bool StatusChecker { get; set; }
        public DateTime CheckDateTime { get; set; }
        public GetListShoeBrandResult ShoeBrand { get; set; } = new GetListShoeBrandResult();
        public GetListShoeImageResult ShoeImages { get; set; } = new GetListShoeImageResult();
    }
    public class GetListShoeBrandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
    public class GetListShoeImageResult
    {
        public Guid Id { get; set; }
        public string ImageData { get; set; } = "";
    }
}
