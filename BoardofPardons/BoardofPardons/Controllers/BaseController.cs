using BoardofPardons.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BoardofPardons.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        //[NonAction]
        //public Boolean CheckUserSession()
        //{
        //    return true;
        //}
        public AccountManager accountManager;
        public bool isSuccess = false;
        public string returnMessage = string.Empty;
        [NonAction]
        public string RenderPartialToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }


        public void sendSubmitEmail()
        {
            accountManager = new AccountManager();
            List<string> toEmail = accountManager.GetlistOfModeratorUser(out returnMessage, out isSuccess);
            int mu1 = (int)WebSecurity.CurrentUserId;
            string useraname = WebSecurity.CurrentUserName;

            if (toEmail.Count > 0)
            {
                Utility.sendSubmitEmail(toEmail, useraname, "New Form Submitted", "");
            }
        }
        public void sendReviewrejectEmail(string toEmail ,string comment)
        {            
            int mu1 = (int)WebSecurity.CurrentUserId;
            string useraname = WebSecurity.CurrentUserName;

            Utility.sendReviewEmail(toEmail, "Review Of Your Form", "Your Form is Rejected Because of " + comment);

        }
        public void sendReviewAcceptEmail(string toEmail, string comment)
        {
            int mu1 = (int)WebSecurity.CurrentUserId;
            string useraname = WebSecurity.CurrentUserName;

            Utility.sendReviewEmail(toEmail, "Review Of Your Form", "Your Form is Accepted <br/>" + comment);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            // OR set the result without redirection:
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/Index.cshtml"
            };
        }
    }
}
