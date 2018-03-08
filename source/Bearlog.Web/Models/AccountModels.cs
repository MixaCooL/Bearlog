﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bearlog.Web.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}