﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.DTO.Results
{
    public class LoginResult : IResult
    {
        public LoginResultData? Data { get; set; }
    }
    public class LoginResultData
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
