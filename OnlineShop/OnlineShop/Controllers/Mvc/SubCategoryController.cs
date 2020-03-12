using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public async Task<ActionResult> Items(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var result = await db.Items.Where(x => x.SubCategoryId == id).Select(x => new ItemViewModel
                {
                    CatTitle = x.SubCategory.Category.Title,
                    Colors = db.ItemColors.Where(y => y.ItemId == x.Id).Select(y => new ColorViewModel { Code = y.Color.ColorCode, Title = y.Color.Title }).ToList(),
                    Description = x.Desciption,
                    Title = x.Title,
                    Link = db.Images.Where(y => y.ItemId == x.Id && y.IsMain == true).Select(y => y.Link).FirstOrDefault(),
                    Price = x.Price,
                    SubCatTitle = x.SubCategory.Title,
                    Id = x.Id
                }).ToListAsync();
                return View(result);
            }
        }
        [Route("SubCats/{id}")]
        public async Task<ActionResult> SubCats(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var result = await db.SubCategories.Where(x => x.CategoryId == id).Select(x => new { x.Id, x.Title }).ToListAsync();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}