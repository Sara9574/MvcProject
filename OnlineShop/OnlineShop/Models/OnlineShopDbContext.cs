using OnlineShop.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext() : base("OnlineShopDbContext")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}