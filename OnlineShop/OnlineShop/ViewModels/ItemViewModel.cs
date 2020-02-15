using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CatTitle { get; set; }
        public string SubCatTitle { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Link { get; set; }
        public int Price { get; set; }
    }
}