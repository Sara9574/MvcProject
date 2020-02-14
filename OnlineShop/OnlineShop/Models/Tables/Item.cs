using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(Item))]
    public class Item
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey(nameof(SubCategoryId))]
        public virtual SubCategory SubCategory { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
    }
}