using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class AuthTokenUserResult
    {
        public bool Result { get; set; }
        public string? AccessToken { get; set; }
        public long? Expires { get; set; }
        public string? Id { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
        public string? Role { get; set; }
    }
}
