using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class IResult
    {
        public bool Result { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
    }
}
