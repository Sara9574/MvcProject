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
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

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
            }
            return null;
        }

        [HttpGet]
        public async Task<ActionResult> Count()
        {
            using (var db = new OnlineShopDbContext())
            {

                var count = await db.InvoiceItems.Where(x => x.Invoice.UserId == CurrentUserId).Select(x => x.Count).DefaultIfEmpty(0).SumAsync(x => x);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
        }

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
            }
            return null;
        }
    }
}