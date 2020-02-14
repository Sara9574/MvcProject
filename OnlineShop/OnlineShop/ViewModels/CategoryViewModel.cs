using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class CategoryViewModel
    {
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public string CatTitle { get; set; }
        public string SubCatTitle { get; set; }
    }
}