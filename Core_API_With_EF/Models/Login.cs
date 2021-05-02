using System;
using System.Collections.Generic;

#nullable disable

namespace Core_API_With_EF.Models
{
    public partial class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Userid { get; set; }
    }
}
