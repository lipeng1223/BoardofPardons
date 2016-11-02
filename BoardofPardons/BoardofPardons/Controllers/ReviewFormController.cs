using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using BoardofPardons.Entity;
using BoardofPardons.Models;
using Rotativa;

namespace BoardofPardons.Controllers
{
    public class ReviewFormController : BaseController
    {
        //
        // GET: /ReviewForm/

        public ActionResult Index()
        {
            accountManager = new AccountManager();
            int mu1 = (int)WebSecurity.CurrentUserId;
            List<Form> ListFormStatus = new List<Form>();
            ListFormStatus = accountManager.GetSubmitedForm(out returnMessage, out isSuccess);
            if (isSuccess)
            {
                return View(ListFormStatus);
            }
            else
            {
                return View(ListFormStatus);
            }
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string AppNumber = collection["AppNumber"];
            string DocketNumber = collection["DocketNumber"];
            string BoardOfNumber = collection["BoardOfNumber"];
            accountManager = new AccountManager();
            int mu1 = (int)WebSecurity.CurrentUserId;
            List<Form> ListFormStatus = new List<Form>();
            ListFormStatus = accountManager.GetSubmitedFormWithFilter(AppNumber, DocketNumber, BoardOfNumber, out returnMessage, out isSuccess);
            if (isSuccess)
            {
                return View(ListFormStatus);
            }
            else
            {
                return View(ListFormStatus);
            }
        }
        public ActionResult review(int id)
        {
            accountManager = new AccountManager();
            AllFormReview ListFormStatus = new AllFormReview();
            ListFormStatus = accountManager.GetAllFormReview(id, out returnMessage, out isSuccess);
            if (isSuccess)
            {
                return View(ListFormStatus);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

      
        [HttpPost]
        public ActionResult submitReview(FormCollection collection, string Command)
        {
            accountManager = new AccountManager();
            int id = Convert.ToInt32(collection["Id"].ToString());
            string comment = Convert.ToString(collection["comment"]);
            int userid = WebSecurity.CurrentUserId;
            //update form 
            //insert review table 
            accountManager.updateFormReview(Command, comment, id, userid, out returnMessage, out isSuccess);
            string Email = accountManager.GetUserEmailByFormId(id, out returnMessage, out isSuccess);
            if (Command == "reject")
            {
                //send Email
               sendReviewrejectEmail(Email, comment);
            }
            else
            {
                //send Email
                sendReviewAcceptEmail(Email, comment);
            }
            return RedirectToAction("Index");
        }
    }
}
