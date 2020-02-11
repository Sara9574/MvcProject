using OnlineShop.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
    public class CustomBaseController : Controller
    {
        public int CurrentUserId { get; set; }
        public string CurrentUserFullname { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var exists = filterContext.HttpContext.Request.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName);
            if (exists)
            {
                var cookieItem = Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookieItem.Value);
                CurrentUserId = int.Parse(ticket.UserData);
                CurrentUserFullname = ticket.Name;
            }
        }
    }
}