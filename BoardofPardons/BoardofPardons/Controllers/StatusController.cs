using BoardofPardons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using BoardofPardons.Entity;
namespace BoardofPardons.Controllers
{
    public class StatusController : BaseController
    {
        //
        // GET: /Status/

        public ActionResult Index()
        {
            accountManager = new AccountManager();
            int mu1 = (int)WebSecurity.CurrentUserId;
            List<FormStatus> ListFormStatus = new List<FormStatus>();
            ListFormStatus = accountManager.GetFormStatusByUserId(mu1, out returnMessage, out isSuccess);
            if (isSuccess)
            {
                return View(ListFormStatus);
            }
            else
            {
                return View(ListFormStatus);
            }
        }
    }
}
