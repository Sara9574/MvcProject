using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(InvoiceItem))]
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int Count { get; set; }
        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public int EachItemPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}