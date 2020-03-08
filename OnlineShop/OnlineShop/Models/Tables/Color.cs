using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(Color))]
    public class Color : BaseLookUpTable
    {
        public string ColorCode { get; set; }
    }
}