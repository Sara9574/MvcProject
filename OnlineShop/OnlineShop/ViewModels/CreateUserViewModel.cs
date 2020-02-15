using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}