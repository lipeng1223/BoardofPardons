using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebMatrix.WebData;
using BoardofPardons.Models;
using BoardofPardons.Entity;
namespace BoardofPardons.Controllers
{
    public class NonInCarceratedController : BaseController
    {
        NonInCarceratedManger objNonIncarc;
        AccountManager objAccountMgr;
        //
        // GET: /Wizard/

        public ActionResult Index()
        {
            return View();
        }
        //step 1 
        public ActionResult step1()
        {
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                Session["formNo"] = formId;
                NonIncarceratedStep1 step1 = objNonIncarc.getNonIncarceratedStep1(formId);
                if (step1 != null)
                    return View(step1);
                else
                    return View();
            }

        }
        [HttpGet]
        public ActionResult showstep(int id)
        {
            objAccountMgr = new AccountManager();
            objNonIncarc = new NonInCarceratedManger();
            if (objAccountMgr.checkFormOwner(id, WebSecurity.CurrentUserId))
            {
                Session["formNo"] = id;
                return RedirectToAction("step1");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult step1(NonIncarceratedStep1 step1, string Command)
        {
            if (Session["formNo"] == null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step1 = objNonIncarc.insertStep1(step1, mu1, Command, out returnMessage, out isSuccess);
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
                        Session["formNo"] = null;
                        return RedirectToAction("index", "FormSelect");
                    }
                }
                else
                {
                    return View(step1);
                }
            }
            else
            {
                Session["formNo"]=null;
                return RedirectToAction("Index", "FormSelect");
            }

        }
        //step 2
        public ActionResult step2()
        {
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep2 step2 = objNonIncarc.getNonIncarceratedStep2(formId);
                if (step2 != null)
                    return View(step2);
                else
                    return View();
            }

        }
        [HttpPost]
        public ActionResult step2(NonIncarceratedStep2 step2, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                objAccountMgr = new AccountManager();
                int mu1 = (int)WebSecurity.CurrentUserId;
                string useraname = WebSecurity.CurrentUserName;
                step2.FormId = (int)Session["formNo"];
                step2 = objNonIncarc.insertStep2(step2, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep3 step3 = objNonIncarc.getNonIncarceratedStep3(formId);
                if (step3 != null)
                    return View(step3);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step3(NonIncarceratedStep3 step3, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step3.FormId = (int)Session["formNo"];
                step3 = objNonIncarc.insertStep3(step3, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep4 step4 = objNonIncarc.getNonIncarceratedStep4(formId);
                if (step4 != null)
                    return View(step4);
                else
                    return View();
            }

        }
        [HttpPost]
        public ActionResult step4(NonIncarceratedStep4 step4, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step4.FormId = (int)Session["formNo"];
                step4 = objNonIncarc.insertStep4(step4, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep5 step5 = objNonIncarc.getNonIncarceratedStep5(formId);
                if (step5 != null)
                    return View(step5);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step5(NonIncarceratedStep5 step5, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step5.FormId = (int)Session["formNo"];
                step5 = objNonIncarc.insertStep5(step5, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep6 step6 = objNonIncarc.getNonIncarceratedStep6(formId);
                if (step6 != null)
                    return View(step6);
                else
                    return View();
            }

        }
        [HttpPost]
        public ActionResult step6(NonIncarceratedStep6 step6, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step6.FormId = (int)Session["formNo"];
                step6 = objNonIncarc.insertStep6(step6, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
            objNonIncarc = new NonInCarceratedManger();
            if (Session["formNo"] == null)
            {
                return View();
            }
            else
            {
                int formId = (int)Session["formNo"];
                NonIncarceratedStep7 step7 = objNonIncarc.getNonIncarceratedStep7(formId);
                if (step7 != null)
                    return View(step7);
                else
                    return View();
            }
        }
        [HttpPost]
        public ActionResult step7(NonIncarceratedStep7 step7, string Command)
        {
            if (Session["formNo"] != null)
            {
                objNonIncarc = new NonInCarceratedManger();
                int mu1 = (int)WebSecurity.CurrentUserId;
                step7.FormId = (int)Session["formNo"];
                step7 = objNonIncarc.insertStep7(step7, mu1, Command, out returnMessage, out isSuccess);
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
                        return RedirectToAction("index", "FormSelect");
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
