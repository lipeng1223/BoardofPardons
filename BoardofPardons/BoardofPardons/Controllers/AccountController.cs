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
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool success = WebSecurity.Login(login.username, login.password, false);
                if (success)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (returnUrl == null)
                    {
                        Response.Redirect("~/Home/index");
                    }
                    else
                    {
                        Response.Redirect(returnUrl);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter Username and Password");
            }
            return View(login);

        }

        [HttpGet]
        public ActionResult Register()
        {
            Entity.User user = new Entity.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(Entity.User register)
        {
            accountManager = new AccountManager();
            if (ModelState.IsValid)
            {
                if (!accountManager.UserExist(register.UserName))
                {
                    accountManager.insertUser(register, out returnMessage, out isSuccess);
                    if (isSuccess)
                    {
                        Response.Redirect("~/account/login");
                    }
                    else
                    {
                        ViewBag.Message = "Registration Failed ! Please Try After Sometime..";
                        return View("Register", register);
                    }
                }
                else
                {
                    ViewBag.Message = "UserName Already Exist";
                    return View("Register", register);
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter all details");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]

        public ActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult RoleCreate(Role role)
        {
            if (ModelState.IsValid)
            {
                if (Roles.RoleExists(role.RoleName))
                {
                    ModelState.AddModelError("Error", "Rolename already exists");
                    return View(role);
                }
                else
                {
                    Roles.CreateRole(role.RoleName);
                    return RedirectToAction("RoleIndex", "Account");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter Username and Password");
            }
            return View(role);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult RoleAddToUser()
        {
            AssignRoleVM objvm = new AssignRoleVM();
            accountManager = new AccountManager();
            List<SelectListItem> listrole = new List<SelectListItem>(); //list 1

            listrole.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var item in Roles.GetAllRoles())
            {
                listrole.Add(new SelectListItem { Text = item, Value = item });
            }
            objvm.RolesList = listrole;



            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            var Userlist = accountManager.GetlistOfUser(out returnMessage, out isSuccess);

            List<SelectListItem> listuser = new List<SelectListItem>(); //list 2

            listuser.Add(new SelectListItem { Text = "Select", Value = "0" });

            foreach (var item in Userlist)
            {
                listuser.Add(new SelectListItem { Text = item.UserName, Value = item.UserName });
            }

            objvm.Userlist = listuser;


            return View(objvm);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        //public ActionResult RoleAddToUser(AssignRoleVM objvm)
        //{
        //    accountManager = new AccountManager();
        //    if (objvm.RoleName == "0")
        //    {
        //        ModelState.AddModelError("RoleName", "Please select RoleName");
        //    }

        //    if (objvm.UserName == "0")
        //    {
        //        ModelState.AddModelError("UserName", "Please select Username");
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        if (Roles.IsUserInRole(objvm.UserName, objvm.RoleName))
        //        {
        //            ViewBag.ResultMessage = "This user already has the role specified !";
        //        }
        //        else
        //        {
        //            Roles.AddUserToRole(objvm.UserName, objvm.RoleName);

        //            ViewBag.ResultMessage = "Username added to the role succesfully !";
        //        }


        //        List<SelectListItem> lirole = new List<SelectListItem>();
        //        lirole.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var item in Roles.GetAllRoles())
        //        {
        //            lirole.Add(new SelectListItem { Text = item, Value = item });
        //        }

        //        objvm.RolesList = lirole;

        //        //get list of users
        //        bool isSuccess = false;
        //        string returnMessage = string.Empty;
        //        var Userlist = accountManager.GetlistOfUser(out returnMessage, out isSuccess);
        //        List<SelectListItem> listuser = new List<SelectListItem>();
        //        listuser.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var item in Userlist)
        //        {
        //            listuser.Add(new SelectListItem { Text = item.UserName, Value = item.UserName });
        //        }
        //        objvm.Userlist = listuser;


        //        return View(objvm);

        //    }
        //    else
        //    {
        //        List<SelectListItem> lirole = new List<SelectListItem>();
        //        lirole.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var item in Roles.GetAllRoles())
        //        {
        //            lirole.Add(new SelectListItem { Text = item, Value = item });
        //        }

        //        objvm.RolesList = lirole;

        //        //get list of users
        //        bool isSuccess = false;
        //        string returnMessage = string.Empty;
        //        var Userlist = accountManager.GetlistOfUser(out returnMessage, out isSuccess);
        //        List<SelectListItem> listuser = new List<SelectListItem>();
        //        listuser.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var item in Userlist)
        //        {
        //            listuser.Add(new SelectListItem { Text = item.UserName, Value = item.UserName });
        //        }

        //        objvm.Userlist = listuser;

        //        ModelState.AddModelError("Error", "Please enter Username and Password");
        //    }
        //    return View(objvm);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult RoleToUser()
        {
            string UserName = Request.Params["UserName"];
            string administrator = Request.Params["administrator"];
            string moderator = Request.Params["moderator"];
            if (!string.IsNullOrEmpty(administrator))
            {
                if (Roles.IsUserInRole(UserName, "administrator"))
                {
                    if (administrator == "off")
                    {
                        Roles.RemoveUserFromRole(UserName, "administrator");
                    }
                }
                else
                {
                    if (administrator == "on")
                    {
                        Roles.AddUserToRole(UserName, "administrator");
                    }
                }

            }
            else
            {
                if (Roles.IsUserInRole(UserName, "administrator"))
                {
                    Roles.RemoveUserFromRole(UserName, "administrator");
                }

            }
            if (!string.IsNullOrEmpty(moderator))
            {
                if (Roles.IsUserInRole(UserName, "moderator"))
                {
                    if (moderator == "off")
                    {
                        Roles.RemoveUserFromRole(UserName, "moderator");
                    }
                }
                else
                {
                    if (moderator == "on")
                    {
                        Roles.AddUserToRole(UserName, "moderator");
                    }
                }

            }
            else
            {
                if (Roles.IsUserInRole(UserName, "moderator"))
                {
                    Roles.RemoveUserFromRole(UserName, "moderator");
                }
            }



            return RedirectToAction("DisplayAllUserroles");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteRoleForUser(AssignRoleVM objvm)
        {
            accountManager = new AccountManager();
            if (objvm.RoleName == "0")
            {
                ModelState.AddModelError("RoleName", "Please select RoleName");
            }

            if (objvm.UserName == "0")
            {
                ModelState.AddModelError("UserName", "Please select Username");
            }

            List<SelectListItem> lirole = new List<SelectListItem>();
            lirole.Add(new SelectListItem { Text = "Select", Value = "0" });

            foreach (var item in Roles.GetAllRoles())
            {
                lirole.Add(new SelectListItem { Text = item, Value = item });
            }

            objvm.RolesList = lirole;


            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            var Userlist = accountManager.GetlistOfUser(out returnMessage, out isSuccess);

            List<SelectListItem> listuser = new List<SelectListItem>();

            listuser.Add(new SelectListItem { Text = "Select", Value = "0" });

            foreach (var item in Userlist)
            {
                listuser.Add(new SelectListItem { Text = item.UserName, Value = item.UserName });
            }

            objvm.Userlist = listuser;


            if (ModelState.IsValid)
            {
                if (Roles.IsUserInRole(objvm.UserName, objvm.RoleName))
                {
                    Roles.RemoveUserFromRole(objvm.UserName, objvm.RoleName);
                    ViewBag.ResultMessage = "Role removed from this user successfully !";
                }
                else
                {
                    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                }

            }

            return View(objvm);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteRoleForUser()
        {
            AssignRoleVM objvm = new AssignRoleVM();
            accountManager = new AccountManager();
            List<SelectListItem> lirole = new List<SelectListItem>();
            lirole.Add(new SelectListItem { Text = "Select", Value = "0" });

            foreach (var item in Roles.GetAllRoles())
            {
                lirole.Add(new SelectListItem { Text = item, Value = item });
            }

            objvm.RolesList = lirole;

            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            var Userlist = accountManager.GetlistOfUser(out returnMessage, out isSuccess);

            List<SelectListItem> listuser = new List<SelectListItem>();

            listuser.Add(new SelectListItem { Text = "Select", Value = "0" });

            foreach (var item in Userlist)
            {
                listuser.Add(new SelectListItem { Text = item.UserName, Value = item.UserName });
            }

            objvm.Userlist = listuser;


            return View(objvm);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult RoleIndex()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.ErrorMessage = TempData["Message"];
            }
            var roles = Roles.GetAllRoles();
            return View(roles);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult RoleDelete(string RoleName)
        {
            try
            {
                Roles.DeleteRole(RoleName);
                return RedirectToAction("RoleIndex", "Account");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("RoleIndex", "Account");
                //throw;
            }

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult DisplayAllUserroles()
        {
            if (TempData["ResultMessage"] != null)
            {
                ViewBag.ResultMessage = TempData["ResultMessage"];
            }
            accountManager = new AccountManager();

            List<SelectListItem> listrole = new List<SelectListItem>(); //list 1
            listrole.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var item in Roles.GetAllRoles())
            {
                listrole.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.RoleName = listrole;

            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            List<AllUser> RoleandUserList = accountManager.GetAllUser(out returnMessage, out isSuccess);
            RoleandUserList = RoleandUserList.GroupBy(a => a.UserName).Select(grp => grp.First()).ToList();
            return View(RoleandUserList);
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Session.Abandon();
            Response.Redirect("~/Account/Login");
            return View();
        }
        [Authorize(Roles = "Administrator")]

        public ActionResult deactivate(int id)
        {

            accountManager = new AccountManager();

            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            accountManager.DeactivateUser(id, out returnMessage, out isSuccess);
            return RedirectToAction("DisplayAllUserroles");
        }
        [Authorize(Roles = "Administrator")]

        public ActionResult active(int id)
        {
            accountManager = new AccountManager();

            //get list of users
            bool isSuccess = false;
            string returnMessage = string.Empty;
            accountManager.ActiveUser(id, out returnMessage, out isSuccess);
            return RedirectToAction("DisplayAllUserroles");
        }

        [HttpPost]
        public ActionResult GetRolesOfUser(string username)
        {
            accountManager = new AccountManager();
            List<AllroleandUser> roleUser = new List<AllroleandUser>();
            if (!string.IsNullOrEmpty(username))
            {
                roleUser = accountManager.GetRolesOfUser(username, out returnMessage, out isSuccess);
            }

            return Json(new { roles = roleUser });
        }

    }
}
