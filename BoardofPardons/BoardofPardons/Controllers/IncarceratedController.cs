using BoardofPardons.Models;
using BoardofPardons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BoardofPardons.Controllers
{
    public class IncarceratedController : BaseController
    {
        // GET: /Incarcerated/
        InCarceratedManger objIncarc;
        AccountManager objAccountMgr;
        public ActionResult Index()
        {
            return View();
        }
        //step 1 
        public ActionResult step1()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep1 step1 = objIncarc.getIncarceratedStep1(formId);
                if (step1 != null)
                    return View(step1);
                else
                    return View();
            }

        }
        [HttpPost]
        public ActionResult step1(IncarceratedStep1 step1, string Command)
        {
            if (Session["formNo"] == null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1= Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception)
                {
                }
                step1 = objIncarc.insertStep1(step1, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    Session["formNo"] = step1.FormId;
                    if (Command == "save")
                    {
                        return RedirectToAction("step2");
                    }
                    else
                    {
                        sendSubmitEmail();
                        return RedirectToAction("PDFView", "PDFReport",new {id=step1.FormId }); //PDFView(int id)
                         //return RedirectToAction("index", "FormSelect");
                    }
                }
                else
                {
                    return View(step1);
                }
            }
            else
            {
                Session["formNo"] = null;
                return RedirectToAction("Index", "FormSelect");
            }


        }
        [HttpGet]
        public ActionResult showstep(int id)
        {
            objAccountMgr = new AccountManager();
            objIncarc = new InCarceratedManger();
            int CurrentUserId = WebSecurity.CurrentUserId;
            try
            {
                CurrentUserId = Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
            }
            catch (Exception)
            {
            }
            if (objAccountMgr.checkFormOwner(id, CurrentUserId))
            {
                Session["formNo"] = id;
                return RedirectToAction("step1");
            }
            else
            {
                return View();
            }
        }
        //step 2
        public ActionResult step2()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep2 step2 = objIncarc.getIncarceratedStep2(formId);
                if (step2 != null)
                    return View(step2);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step2(IncarceratedStep2 step2, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1= Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception)
                {

                }
                step2.FormId = (int)Session["formNo"];
                step2 = objIncarc.insertStep2(step2, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return RedirectToAction("step3");
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step2.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step1");
                    }
                }
                else
                {
                    return View(step2);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }

        }
        //step 3
        public ActionResult step3()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep3 step3 = objIncarc.getIncarceratedStep3(formId);
                if (step3 != null)
                    return View(step3);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step3(IncarceratedStep3 step3, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1 = Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception)
                {

                }
                step3.FormId = (int)Session["formNo"];
                step3 = objIncarc.insertStep3(step3, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return RedirectToAction("step4");
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step3.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step2");
                    }
                }
                else
                {
                    return View(step3);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }
        }
        //step 4
        public ActionResult step4()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep4 step4 = objIncarc.getIncarceratedStep4(formId);
                if (step4 != null)
                    return View(step4);
                else
                    return View();
            }

        }
        [HttpPost]
        public ActionResult step4(IncarceratedStep4 step4, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1 = Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception)
                {
                }
                step4.FormId = (int)Session["formNo"];
                step4 = objIncarc.insertStep4(step4, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return RedirectToAction("step5");
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step4.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step3");
                    }
                }
                else
                {
                    return View(step4);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }

        }
        //step 5
        public ActionResult step5()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep5 step5 = objIncarc.getIncarceratedStep5(formId);
                if (step5 != null)
                    return View(step5);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step5(IncarceratedStep5 step5, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1= Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception)
                {
                }
                step5.FormId = (int)Session["formNo"];
                step5 = objIncarc.insertStep5(step5, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return RedirectToAction("step6");
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step5.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step5");
                    }
                }
                else
                {
                    return View(step5);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }

        }
        //step 6
        public ActionResult step6()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep6 step6 = objIncarc.getIncarceratedStep6(formId);
                if (step6 != null)
                    return View(step6);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step6(IncarceratedStep6 step6, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                step6.FormId = (int)Session["formNo"];
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1= Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception){
                }
                step6 = objIncarc.insertStep6(step6, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return RedirectToAction("step7");
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step6.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step5");
                    }
                }
                else
                {
                    return View(step6);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }

        }
        //step 7
        public ActionResult step7()
        {
            objIncarc = new InCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                IncarceratedStep7 step7 = objIncarc.getIncarceratedStep7(formId);
                if (step7 != null)
                    return View(step7);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step7(IncarceratedStep7 step7, string Command)
        {
            if (Session["formNo"] != null)
            {
                objIncarc = new InCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                try
                {
                    mu1= Session["UserId"] == null ? WebSecurity.CurrentUserId : (int)Session["UserId"];
                }
                catch (Exception){
                }
                step7.FormId = (int)Session["formNo"];
                step7 = objIncarc.insertStep7(step7, mu1, Command, out returnMessage, out isSuccess);
                if (isSuccess)
                {
                    if (Command == "save")
                    {
                        return View(step7);
                    }
                    else if (Command == "submit")
                    {
                        sendSubmitEmail();
                        Session["formNo"] = null;
                        return RedirectToAction("PDFView", "PDFReport", new { id = step7.FormId }); //PDFView(int id)
                        //return RedirectToAction("index", "FormSelect");
                    }
                    else
                    {
                        return RedirectToAction("step6");
                    }
                }
                else
                {
                    return View(step7);
                }
            }
            else
            {
                return RedirectToAction("Index", "FormSelect");
            }
        }
    }
}
