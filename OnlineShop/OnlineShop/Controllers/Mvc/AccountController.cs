using Newtonsoft.Json;
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
using System.Web.Security;

namespace OnlineShop.Controllers.Mvc
{
    public class AccountController : CustomBaseController
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            string returnUrl = Request.Form["ReturnUrl"] == "" || Request.Form["ReturnUrl"] == null ? "/home/index" : Request.Form["ReturnUrl"];
            using (var db = new OnlineShopDbContext())
            {
                var user = await db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    ViewBag.Error = "ایمیل یا رمز عبور اشتباه است!";
                    return View();
                }
                if (user.IsReviewed && !user.IsVerified)
                {
                    ViewBag.Error = "حساب کاربری شما رد شده!";
                    return View();
                }
                if (!user.IsReviewed)
                {
                    ViewBag.Error = "حساب کاربری شما هنوز بررسی و تایید نشده!";
                    return View();
                }
                RoleViewModel roleModel = new RoleViewModel { RoleId = user.RoleId, UserId = user.Id };
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    user.Fullname,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    JsonConvert.SerializeObject(roleModel),
                    FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                if (user.RoleId == 2)
                {
                    returnUrl = "/admin/panel";
                }
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<ActionResult> Signup(CreateUserViewModel model)
        {
            using (var db = new OnlineShopDbContext())
            {
                var newUser = new User
                {
                    Email = model.Email,
                    Fullname = model.Fullname,
                    Password = model.Password,
                    Mobile = model.Mobile,
                    RoleId = 1 //normal user
                    ,
                    IsVerified = false,
                    IsReviewed = false
                };
                db.Users.Add(newUser);
                await db.SaveChangesAsync();
                //RoleViewModel roleModel = new RoleViewModel { RoleId = 1, UserId = newUser.Id };
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                //   newUser.Fullname,
                //   DateTime.Now,
                //   DateTime.Now.AddMinutes(30),
                //   false,
                //   JsonConvert.SerializeObject(roleModel),
                //   FormsAuthentication.FormsCookiePath);
                //string encTicket = FormsAuthentication.Encrypt(ticket);
                //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                return Redirect("/account/pending");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/home/index");
        }

        public ActionResult Test()
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                "test",
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                "test",
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            //FormsAuthentication.SetAuthCookie(user.Fullname, false);
            //var test = User.Identity.Name;
            //UserId
            return null;
        }
        [CustomAuthorize]
        public async Task<ActionResult> UserProfile()
        {
            using (var db = new OnlineShopDbContext())
            {
                var user = await db.Users.Where(x => x.Id == CurrentUserId).Select(x => new UserProfileResponseViewModel
                {
                    Email = x.Email,
                    Fullname = x.Fullname,
                    Mobile = x.Mobile
                }).FirstOrDefaultAsync();
                return View(user);
            }
        }
        public ActionResult Pending()
        {
            return View();
        }
    }
}