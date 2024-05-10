using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class DeteleBrandCheckResult : IResult
    {
        public DeleteBrandResultData? Data { get; set; }
    }
    public class DeleteBrandResultData
    {
        public Guid Id { get; set; }
    }
}
