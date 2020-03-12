using Newtonsoft.Json;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class AjaxController : Controller
    {

        public async Task<ActionResult> Categories()
        {
            using (var db = new OnlineShopDbContext())
            {
                var categories = await db.Categories.Select(x => new { x.Id, x.Title }).ToListAsync();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Colors()
        {
            using (var db = new OnlineShopDbContext())
            {
                var result = await db.Colors.Select(x => new  { x.Id, x.ColorCode, x.Title }).ToListAsync();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}