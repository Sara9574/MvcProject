using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Tables
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool? IsVerified { get; set; }
    }
}