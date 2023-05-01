using DemoApp.DataAccess;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            using (var context = new UserDBEntities())
            {
                bool isValid = context.Users.Any(x => x.Email.ToLower() == user.Email.ToLower() 
                                && x.Password.ToLower() == user.Password.ToLower());
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("IndexA");
                }
                else
                {
                    ViewBag.IsValid = "Not a valid user";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
       
        public ActionResult IndexA()
        {
            return View();
        }
        
        public ActionResult IndexB()
        {
            return View();
        }
    }
}