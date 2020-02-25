using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public string Color { get; set; }
        public int EachPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}