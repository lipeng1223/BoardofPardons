using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardofPardons.Controllers
{
    public class FormSelectController : Controller
    {
        //
        // GET: /FormSelect/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NonInCarcerated()
        {
            return View();
        }
        public ActionResult InCarcerated()
        {
            return View();
        }
    }
}
