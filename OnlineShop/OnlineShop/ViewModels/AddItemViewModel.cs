using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class AddItemViewModel
    {
        public string Title { get; set; }
        public int SubCatId { get; set; }
        public int Price { get; set; }
        public List<int> Colors { get; set; }
        public List<int> Sizes { get; set; }
        public string Description { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }
    }
}