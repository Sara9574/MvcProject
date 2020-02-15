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
                var result = await db.Items.Where(x => x.SubCategoryId == id).Select(x => new ItemViewModel {
                    CatTitle = x.SubCategory.Category.Title,
                    Color = x.Color.Title,
                    Description = x.Desciption,
                    Title = x.Title,
                    Link = x.Image.Link,
                    Price = x.Price,
                    SubCatTitle = x.SubCategory.Title
                }).ToListAsync();
                return View(result);
            } 
        }
    }
}