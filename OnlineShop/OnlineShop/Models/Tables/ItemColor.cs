using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(ItemColor))]
    public class ItemColor
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public int ColorId { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }
    }
}