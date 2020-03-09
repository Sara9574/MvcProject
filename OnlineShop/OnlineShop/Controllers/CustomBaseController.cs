using Newtonsoft.Json;
using OnlineShop.Models.Tables;
using OnlineShop.ViewModels;
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
        public int CurrentUserRoleId { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var exists = filterContext.HttpContext.Request.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName);
            if (exists)
            {
                var cookieItem = Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookieItem.Value);
                var userData = JsonConvert.DeserializeObject<RoleViewModel>(ticket.UserData);
                CurrentUserId = userData.UserId;
                CurrentUserRoleId = userData.RoleId;
                CurrentUserFullname = ticket.Name;
            }
        }
    }
}