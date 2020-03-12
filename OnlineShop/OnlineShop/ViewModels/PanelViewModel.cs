using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class PanelViewModel
    {
        public int VerifiedUserCount { get; set; }
        public int UnVerifiedUserCount { get; set; }
        public int UnVerifiedFeedbackCount { get; set; }
        public int ProductCount { get; set; }
    }
}