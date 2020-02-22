using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(Invoice))]
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int InvoiceStateId { get; set; }
        [ForeignKey(nameof(InvoiceStateId))]
        public InvoiceState InvoiceState { get; set; }
    }
}