using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers.Mvc
{
    public class ErrorController : Controller
    {
        public ActionResult Unathorized()
        {
            return View();
        }
    }
}