using OnlineShop.Models;
using OnlineShop.Models.Tables;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace OnlineShop.Controllers.Api
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //public User CurrentUser()
        //{
        //    var user = new User { };
        //    var cookieItem = Request.Headers.GetCookies(FormsAuthentication.FormsCookieName).FirstOrDefault();
        //    if (cookieItem != null)
        //    {
        //        // var cookieItem = Request.Cookies[FormsAuthentication.FormsCookieName];
        //        //var ticket = FormsAuthentication.Decrypt(cookieItem.ToString());
        //        var value = cookieItem[FormsAuthentication.FormsCookieName].Value;
        //        var ticket = FormsAuthentication.Decrypt(value);
            

        //    }

        //} 
        [HttpGet]
        public IHttpActionResult Test(CreateUserViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IHttpActionResult> Signup(CreateUserViewModel model)
        {
            using (var db = new OnlineShopDbContext())
            {
                var newUser = new User
                {
                    Email = model.Email,
                    Fullname = model.Fullname,
                    Password = model.Password
                };
                db.Users.Add(newUser);
                await db.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
      
        public async Task<HttpResponseMessage> Login(LoginViewModel model)
        {
            var cookieItem = Request.Headers.GetCookies(FormsAuthentication.FormsCookieName).FirstOrDefault();
            if (cookieItem != null)
            {
                // var cookieItem = Request.Cookies[FormsAuthentication.FormsCookieName];
                //var ticket = FormsAuthentication.Decrypt(cookieItem.ToString());
                var value = cookieItem[FormsAuthentication.FormsCookieName].Value;
                var ticket = FormsAuthentication.Decrypt(value);
            }
            var response = Request.CreateResponse();
            using (var db = new OnlineShopDbContext())
            {
                var user = await db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        user.Email,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        false,
        user.Id.ToString(),
        FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                var cookies = new List<CookieHeaderValue>();
                cookies.Add(new CookieHeaderValue(FormsAuthentication.FormsCookieName, encTicket));
                response.Headers.AddCookies(cookies);

                //FormsAuthentication.SetAuthCookie(user.Fullname, false);
                //var test = User.Identity.Name;
                //UserId
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
        }
    }
}
