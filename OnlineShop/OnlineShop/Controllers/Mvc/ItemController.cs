using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class ItemController : Controller
    {
        // GET: Item
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var item = db.Items.Where(x=>x.Id==id).Select(x=> new ItemViewModel {
                    CatTitle = x.SubCategory.Category.Title,
                    Color = x.Color.Title,
                    Description = x.Desciption,
                    Title = x.Title,
                    Link = x.Image.Link,
                    Price = x.Price,
                    SubCatTitle = x.SubCategory.Title,
                    Id = x.Id
                }).FirstOrDefault();
                return View(item);
            }
        }
    }
}