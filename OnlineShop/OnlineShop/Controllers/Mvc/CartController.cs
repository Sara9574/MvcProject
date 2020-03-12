using OnlineShop.Filters;
using OnlineShop.Models;
using OnlineShop.Models.Tables;
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
    public class CartController : CustomBaseController
    {
        public async Task UpdatePrice(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var invoice = await db.Invoices.FindAsync(id);
                invoice.InvoiceSum = await db.InvoiceItems.Where(x => x.InvoiceId == id).Select(x => x.TotalPrice).DefaultIfEmpty(0).SumAsync(x => x);
                await db.SaveChangesAsync();
            }
        }
        // GET: Cart
        [HttpGet]
        [CustomAuthorize]
        public async Task<ActionResult> Index()
        {
            using (var db = new OnlineShopDbContext())
            {
                var list = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId && x.Invoice.InvoiceStateId == 1).Select(x => new CartViewModel()
                {
                    Color = db.ItemColors.Where(y => y.ItemId == x.ItemId).Select(y => y.Color.Title).FirstOrDefault(),
                    Title = x.Item.Title,
                    Count = x.Count,
                    ImageLink = db.Images.Where(y => y.ItemId == x.ItemId && y.IsMain == true).Select(y => y.Link).FirstOrDefault(),
                    Id = x.ItemId,
                    EachPrice = x.EachItemPrice,
                    TotalPrice = x.TotalPrice,
                }).ToListAsync();
                return View(list);
            }
        }
        [CustomAuthorize]
        [HttpPost]
        public async Task<ActionResult> Add(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                int invoiceId;
                var currentInvoice = await db.Invoices.Where(x => x.UserId == CurrentUserId).FirstOrDefaultAsync();
                if (currentInvoice == null)
                {
                    var invoice = new Invoice()
                    {
                        UserId = CurrentUserId,
                        InvoiceStateId = 1,
                        InvoiceSum = 0,
                        SubmissionDate = DateTime.Now
                    };
                    db.Invoices.Add(invoice);
                    await db.SaveChangesAsync();
                    invoiceId = invoice.Id;
                }
                else
                {
                    invoiceId = currentInvoice.Id;
                }
                var currentInvoiceItems = await db.InvoiceItems.Where(x => x.InvoiceId == invoiceId).ToListAsync();
                if (currentInvoiceItems.Any(x => x.ItemId == id))
                {
                    var currentInvoiceItem = currentInvoiceItems.Where(x => x.ItemId == id).FirstOrDefault();
                    currentInvoiceItem.Count++;
                    currentInvoiceItem.TotalPrice = (currentInvoiceItem.Count * currentInvoiceItem.EachItemPrice);
                    currentInvoiceItem.SubmissionDate = DateTime.Now;
                    await db.SaveChangesAsync();
                }
                else
                {
                    var item = await db.Items.FindAsync(id);
                    var invoiceItem = new InvoiceItem()
                    {
                        InvoiceId = invoiceId,
                        ItemId = id,
                        SubmissionDate = DateTime.Now,
                        Count = 1,
                        EachItemPrice = item.Price,
                        TotalPrice = item.Price,
                    };
                    db.InvoiceItems.Add(invoiceItem);
                    await db.SaveChangesAsync();
                }
                await UpdatePrice(invoiceId);
            }
            return null;
        }

        [CustomAuthorize]
        [HttpGet]
        public async Task<ActionResult> Count()
        {
            using (var db = new OnlineShopDbContext())
            {
                var count = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId).Select(x => x.Count).DefaultIfEmpty(0).SumAsync(x => x);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
        }

        [CustomAuthorize]
        [HttpGet]
        public async Task<ActionResult> ItemCount()
        {
            using (var db = new OnlineShopDbContext())
            {
                var items = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId).Select(x =>
                new ItemCountViewModel { Id = x.ItemId, Count = x.Count }).ToListAsync();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
        }

        [CustomAuthorize]
        [HttpPost]
        public async Task<ActionResult> Remove(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var currentInvoiceItems = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId).ToListAsync();
                if (currentInvoiceItems.Where(x => x.ItemId == id).Select(x => x.Count).FirstOrDefault() > 1)
                {
                    var currentInvoiceItem = currentInvoiceItems.Where(x => x.ItemId == id).FirstOrDefault();
                    currentInvoiceItem.Count--;
                    currentInvoiceItem.TotalPrice = (currentInvoiceItem.Count * currentInvoiceItem.EachItemPrice);
                    currentInvoiceItem.SubmissionDate = DateTime.Now;
                    await db.SaveChangesAsync();
                }
                else
                {
                    var invoiceItem = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId && x.ItemId == id).FirstOrDefaultAsync();
                    db.InvoiceItems.Remove(invoiceItem);
                    await db.SaveChangesAsync();
                }
                await UpdatePrice(currentInvoiceItems.Select(x => x.InvoiceId).FirstOrDefault());
            }
            return null;
        }

        [CustomAuthorize]
        [HttpGet]
        public async Task<ActionResult> FactorInfo()
        {
            using (var db = new OnlineShopDbContext())
            {
                var invoice = await db.Invoices.Where(x => x.UserId == CurrentUserId && x.InvoiceStateId == 1).FirstOrDefaultAsync();
                FactorInfoViewModel factorInfo = new FactorInfoViewModel()
                {
                    Delivery = 10000,
                    Discount = 0,
                    Total = invoice.InvoiceSum,
                    Sum = 10000 + invoice.InvoiceSum
                };
                return Json(factorInfo, JsonRequestBehavior.AllowGet);
            }
        }

        [CustomAuthorize]
        [HttpPost]
        public async Task Trash(int id)
        {
            using (var db = new OnlineShopDbContext())
            {
                var invoiceItem = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId && x.ItemId == id).FirstOrDefaultAsync();
                var invoiceId = invoiceItem.InvoiceId;
                db.InvoiceItems.Remove(invoiceItem);
                await db.SaveChangesAsync();
                await UpdatePrice(invoiceId);
            }
        }
    }
}