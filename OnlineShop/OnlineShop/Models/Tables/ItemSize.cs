using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(ItemSize))]
    public class ItemSize
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public int SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; }
    }
}