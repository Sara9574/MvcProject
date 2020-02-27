using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class FactorInfoViewModel
    {
        public int Total { get; set; }
        public int Discount { get; set; }
        public int Delivery { get; set; }
        public int Sum { get; set; }
    }
}