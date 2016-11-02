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
    public class PDFReportController : BaseController
    {
        // GET: PDFReport
        public ActionResult ActionToPdfFile(AllFormReview ListFormStatus)
        {
            accountManager = new AccountManager();
            //AllFormReview ListFormStatus = new AllFormReview();
            ListFormStatus = accountManager.GetAllFormReview(ListFormStatus.Id, out returnMessage, out isSuccess);
            return View("ActionToPdfFile", ListFormStatus);
        }

        public ActionResult PDFView(int id)
        {
            accountManager = new AccountManager();
            AllFormReview ListFormStatus = new AllFormReview();
            //ListFormStatus = accountManager.GetAllFormReview(id, out returnMessage, out isSuccess);
            ListFormStatus.Id = id;
            try
            {
                return new ActionAsPdf("ActionToPdfFile", ListFormStatus);
                //return new RazorPDF.PdfResult(ListFormStatus, "PDFView");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}