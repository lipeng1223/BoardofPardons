using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BoardofPardons.Models;
using WebMatrix.WebData;

using BoardofPardons.Entity;

namespace BoardofPardons.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserManagerController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            Entity.User user = new Entity.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Entity.User register)
        {
            accountManager = new AccountManager();
            if (ModelState.IsValid)
            {
                if (!accountManager.UserExist(register.UserName))
                {
                    var CreatedUser= accountManager.insertUser(register, out returnMessage, out isSuccess);

                    if (isSuccess)
                    {
                        Session["UserId"] = CreatedUser.Id;
                        Response.Redirect("~/account/DisplayAllUserroles");
                    }
                    else
                    {
                        Session["UserId"] = null;
                        ViewBag.Message = "Registration Failed ! Please Try After Sometime..";
                        return View("Create", register);
                    }
                }
                else
                {
                    Session["UserId"] = null;
                    ViewBag.Message = "UserName Already Exist";
                    return View("Create", register);
                }
            }
            else
            {
                Session["UserId"] = null;
                ModelState.AddModelError("Error", "Please enter all details");
            }
            return View();
        }

    }
}