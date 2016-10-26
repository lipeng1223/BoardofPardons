using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using BoardofPardons.Models;
namespace BoardofPardons.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index","Home");
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
