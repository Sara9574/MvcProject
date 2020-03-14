using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Models.Tables;
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
        public ActionResult UserManagement()
        {
            using (var db = new OnlineShopDbContext())
            {
                var list = db.Users.Where(x => x.IsVerified == false).ToList();
                return View(list);
            }
        }

        public ActionResult Products()
        {
            using (var db = new OnlineShopDbContext())
            {
                var list = db.Items.Select(x => new ProductViewModel
                {
                    Category = x.SubCategory.Category.Title,
                    Link = db.Images.Where(y => y.ItemId == x.Id && y.IsMain == true).Select(y => y.Link).FirstOrDefault(),
                    Price = x.Price,
                    SubCat = x.SubCategory.Title,
                    Title = x.Title,
                    ShowOnSite = x.ShowOnSite == true ? "بله" : "خیر",
                    Id = x.Id
                }).ToList();
                return View(list);
            }
        }

        public ActionResult AddProduct()
        {
            using (var db = new OnlineShopDbContext())
            {
                ViewBag.Colors = JsonConvert.SerializeObject(db.Colors.Select(x => new { x.Id, x.ColorCode, x.Title }).ToList());
                ViewBag.Sizes = JsonConvert.SerializeObject(db.Sizes.Select(x => new { x.Id, x.Tag, x.Title }).ToList());
                return View();
            }
        }
    }
}