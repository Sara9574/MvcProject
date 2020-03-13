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
                var item = db.Items.Where(x => x.Id == id).Select(x => new ItemViewModel
                {
                    CatTitle = x.SubCategory.Category.Title,
                    Colors = db.ItemColors.Where(y => y.ItemId == x.Id).Select(y => new ColorViewModel { Id = y.ColorId, Code = y.Color.ColorCode, Title = y.Color.Title }).ToList(),
                    Description = x.Desciption,
                    Title = x.Title,
                    Link = db.Images.Where(y => y.ItemId == x.Id && y.IsMain == true).Select(y => y.Link).FirstOrDefault(),
                    Price = x.Price,
                    SubCatTitle = x.SubCategory.Title,
                    Id = x.Id,
                    OtherImages = db.Images.Where(y => y.ItemId == x.Id && y.IsMain != true).Select(y => y.Link).ToList(),
                    Sizes = db.ItemSizes.Where(y => y.ItemId == x.Id).Select(y => new SizeViewModel { Id = y.SizeId, Tag = y.Size.Tag }).ToList(),
                }).FirstOrDefault();
                return View(item);
            }
        }

        public ActionResult SearchResult(string q)
        {
            using (var db = new OnlineShopDbContext())
            {
                var reuslt = db.Items.Where(x => x.Title.Contains(q) || x.SubCategory.Title.Contains(q) ||
                db.ItemColors.Where(y => y.ItemId == x.Id).Select(y => y.Color.Title).Contains(q)).Select(x => new ItemViewModel
                {
                    CatTitle = x.SubCategory.Category.Title,
                    Colors = db.ItemColors.Where(y => y.ItemId == x.Id).Select(y => new ColorViewModel { Id = y.ColorId, Code = y.Color.ColorCode, Title = y.Color.Title }).ToList(),
                    Description = x.Desciption,
                    Title = x.Title,
                    Link = db.Images.Where(y => y.ItemId == x.Id && y.IsMain == true).Select(y => y.Link).FirstOrDefault(),
                    Price = x.Price,
                    SubCatTitle = x.SubCategory.Title,
                    Id = x.Id,
                    OtherImages = db.Images.Where(y => y.ItemId == x.Id && y.IsMain != true).Select(y => y.Link).ToList(),
                    Sizes = db.ItemSizes.Where(y => y.ItemId == x.Id).Select(y => new SizeViewModel { Id = y.SizeId, Tag = y.Size.Tag }).ToList(),
                }).ToList();
                return View(reuslt);
            }
        }
    }
}