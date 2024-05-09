using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Params
{
    public class LoginParam
    {
        public required string User { get; set; }
        public required string Password { get; set; }
    }
}
