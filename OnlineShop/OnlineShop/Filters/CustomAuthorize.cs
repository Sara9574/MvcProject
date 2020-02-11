using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace OnlineShop.Filters
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var exists = httpContext.Request.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName);
            if (!exists)
            {
                return false;
            }
            return true;
        }
        
    }
}