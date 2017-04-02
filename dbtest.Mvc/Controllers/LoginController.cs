using dbtest.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace dbtest.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Usuário/senha informados não existem.");
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Login, false);
                var ticket = new FormsAuthenticationTicket(model.Login, false, Convert.ToInt32(FormsAuthentication.Timeout.TotalMinutes));
                string hashedTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);
                HttpContext.Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
