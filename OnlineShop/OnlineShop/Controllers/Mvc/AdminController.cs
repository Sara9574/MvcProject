using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class AdminController : CustomBaseController
    {
        public ActionResult Panel()
        {
            using (var db = new OnlineShopDbContext())
            {
                PanelViewModel model = new PanelViewModel();
                model.UnVerifiedFeedbackCount = 4;
                model.VerifiedUserCount = 10;
                model.UnVerifiedUserCount = 3;
                model.ProductCount = 30;
                return View(model);
            }
        }
    }
}