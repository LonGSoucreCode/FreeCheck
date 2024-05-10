using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Params
{
    public class UpdateBrandCheckParam
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
    }
}
