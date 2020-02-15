using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(Image))]
    public class Image
    {
        public int Id { get; set; }
        public string Link { get; set; }
    }
}