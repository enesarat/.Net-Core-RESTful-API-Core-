﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete.DTO
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
