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
        [HttpPost]
        public ActionResult AddProduct(AddItemViewModel model)
        {
            using (var db = new OnlineShopDbContext())
            {
                var item = new Item
                {
                    Desciption = model.Description,
                    Price = model.Price,
                    ShowOnSite = true,
                    SubCategoryId = model.SubCatId,
                    Title = model.Title
                };
                db.Items.Add(item);
                db.SaveChanges();
                foreach (var color in model.Colors)
                {
                    var itemColor = new ItemColor
                    {
                        ColorId = color,
                        ItemId = item.Id
                    };
                    db.ItemColors.Add(itemColor);
                }
                foreach (var size in model.Sizes)
                {
                    var itemSize = new ItemSize
                    {
                        SizeId = size,
                        ItemId = item.Id
                    };
                    db.ItemSizes.Add(itemSize);
                }
                var link1 = new Image{IsMain = true,ItemId = item.Id,Link = model.Link1,};
                var link2 = new Image { IsMain = false, ItemId = item.Id, Link = model.Link2, };
                var link3 = new Image { IsMain = false, ItemId = item.Id, Link = model.Link3, };
                var link4 = new Image { IsMain = false, ItemId = item.Id, Link = model.Link4, };
                db.Images.Add(link1);
                db.Images.Add(link2);
                db.Images.Add(link3);
                db.Images.Add(link4);
                db.SaveChanges();
                return Json(item.Id, JsonRequestBehavior.AllowGet);
            }
        }
    }
}