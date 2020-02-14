using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public ActionResult Items(int id)
        {
            ViewBag.Test = id;
            return View();
        }
    }
}