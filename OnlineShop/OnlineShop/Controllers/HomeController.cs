using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Categories()
        {
            using (var db = new OnlineShopDbContext())
            {
                var result = db.SubCategories.Select(x => new CategoryViewModel()
                {
                    CatId = x.CategoryId,
                    CatTitle = x.Category.Title,
                    SubCatId = x.Id,
                    SubCatTitle = x.Title
                }).ToList();
                var cats = db.Categories.Select(x => new
                {
                    x.Id,
                    x.Title,
                }).ToList();
                ViewBag.Cats = JsonConvert.SerializeObject(cats);
                return PartialView(result);
            }
        }
    }
}