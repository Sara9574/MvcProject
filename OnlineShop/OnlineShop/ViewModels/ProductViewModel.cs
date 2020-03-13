using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string SubCat { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string ShowOnSite { get; set; }
        public string Link { get; set; }
    }
}