﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(User))]
    public class User
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public bool IsVerified { get; set; }
        public bool IsReviewed { get; set; }
    }
}