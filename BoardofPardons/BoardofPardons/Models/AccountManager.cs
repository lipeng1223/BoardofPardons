using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoardofPardons.Entity;
using WebMatrix.WebData;
using System.Web.Security;
using System.Web.Hosting;
using System.IO;
namespace BoardofPardons.Models
{
    public class AccountManager
    {
        public List<User> GetlistOfUser(out string result, out bool isSuccess)
        {
            try
            {
                List<User> listUser = new List<User>();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    listUser = dbcontext.Database.SqlQuery<User>(@"select Id,
                                                                UserName,
                                                                Suffix,
                                                                FirstName,
                                                                MiddleName,
                                                                LastName,
                                                                Gender,
                                                                BirthDate,
                                                                SSNumber,
                                                                Address,
                                                                Apartment,
                                                                City,
                                                                State,
                                                                Zip,
                                                                Homephone,
                                                                CellPhone,
                                                                Email,
                                                                PlaceOfBirth ,'' as Password,Status,CreatedAt,UpdatedAt from users").ToList();
                    //listUser = dbcontext.Users.ToList();
                }
                isSuccess = false;
                result = "Success";
                return listUser;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return null;
            }
        }

        public List<AllUser> GetAllUser(out string result, out bool isSuccess)
        {
            try
            {
                List<AllUser> listUser = new List<AllUser>();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    listUser = dbcontext.Database.SqlQuery<AllUser>(@"SELECT     Users.Id, Users.UserName, Users.Email, Users.Status, Users.UpdatedAt, 
                       Users.CreatedAt, case webpages_UsersInRoles.RoleId when 1 then 'Administrator' when 2 then 'Moderator' when 3 then 'User' end as Role
                      FROM         Users INNER JOIN
                      webpages_UsersInRoles ON Users.Id = webpages_UsersInRoles.UserId").ToList();
                    //listUser = dbcontext.Users.ToList();
                }
                isSuccess = false;
                result = "Success";
                return listUser;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return null;
            }
        }
        public List<AllroleandUser> GetlistOfUserwithRole(out string result, out bool isSuccess)
        {
            List<AllroleandUser> listUser = new List<AllroleandUser>();
            try
            {
                string Query = @"SELECT U.UserName,ro.RoleName FROM Users U 
                                Left JOIN webpages_UsersInRoles WU on U.Id = WU.UserId 
                                Left JOIN webpages_Roles ro on WU.RoleId = ro.RoleId";
                List<User> list = new List<User>();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    listUser = dbcontext.Database.SqlQuery<AllroleandUser>(Query).ToList();
                    result = "";
                    isSuccess = true;
                    return listUser;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                throw;
            }
        }
        public List<string> GetlistOfModeratorUser(out string result, out bool isSuccess)
        {
            try
            {
                List<string> listUser = new List<string>();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    listUser = dbcontext.Database.SqlQuery<string>(@"SELECT U.Email FROM Users U 
                                Left JOIN webpages_UsersInRoles WU on U.Id = WU.UserId 
                                Left JOIN webpages_Roles ro on WU.RoleId = ro.RoleId where ro.RoleName = 'moderator'").ToList();

                }
                isSuccess = true;
                result = "Success";
                return listUser;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return null;
            }
        }
        public string GetUserEmailByFormId(int formId, out string result, out bool isSuccess)
        {
            try
            {

                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    int uId = dbcontext.Forms.Where(a => a.id == formId).FirstOrDefault().UserId;
                    string UEmail = dbcontext.Users.Where(a => a.Id == uId).FirstOrDefault().Email;
                    isSuccess = true;
                    result = "Success";
                    return UEmail;

                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return null;
            }
        }
        public bool UserExist(string username)
        {
            return WebSecurity.UserExists(username);

        }
        public User insertUser (Entity. User user, out string result, out bool isSuccess)
        {
            try
            {
                WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new
                {
                    Suffix = user.Suffix,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    BirthDate = user.BirthDate,
                    SSNumber = user.SSNumber,
                    Address = user.Address,
                    Apartment = user.Apartment,
                    City = user.City,
                    State = user.State,
                    Zip = user.Zip,
                    Homephone = user.Homephone,
                    CellPhone = user.CellPhone,
                    PlaceOfBirth = user.PlaceOfBirth,
                    Email = user.Email,
                    status = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                Roles.AddUserToRole(user.UserName, "normaluser");
                //using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                //{                    
                //    //dbcontext.Users.Add(user);
                //    result = "Success";
                //    isSuccess = true;
                //    return user;
                //}
                result = "Success";
                isSuccess = true;
                return user;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                      new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return user;
            }
        }
        public List<FormStatus> GetFormStatusByUserId(int userId, out string result, out bool isSuccess)
        {
            List<FormStatus> listOfForm = new List<FormStatus>();
            try
            {
                string Query = @"SELECT Forms.Id, case Forms.Type when 1 then 'Incarcerated'when 2 then 'Not Incarcerated' end as Type, Forms.CreatedAt,Forms.UpdatedAt,
			                 case Forms.Status  when 0 then 'Draft' when 1 then 'Waiting for Review'when 2 then 'Accepted' when 3 then 'Rejected' end as Status
                             FROM Forms INNER JOIN webpages_Membership ON Forms.UserId = webpages_Membership.UserId
                             WHERE     (Forms.UserId = " + userId + ")";

                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    listOfForm = dbcontext.Database.SqlQuery<FormStatus>(Query).ToList();
                    result = "";
                    isSuccess = true;
                    return listOfForm;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                throw;
            }
        }
        public List<Form> GetSubmitedForm(out string result, out bool isSuccess)
        {
            List<Form> listOfForm = new List<Form>();
            try
            {
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    if (dbcontext.Forms.ToList().Count > 0)
                    {
                        listOfForm = dbcontext.Forms.ToList().Where(b => b.Status == 1).OrderBy(a => a.CreatedAt).OrderBy(a => a.UpdatedAt).ToList();

                    }
                    result = "";
                    isSuccess = true;
                    return listOfForm;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                throw;
            }
        }
        public List<Form> GetSubmitedFormWithFilter(string AppNumber, string DocketNumber, string BoardOfNumber, out string result, out bool isSuccess)
        {
            List<Form> listOfForms = new List<Form>();
            List<Form> FilterfForms = new List<Form>();
            try
            {
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    listOfForms = dbcontext.Forms.Where(b => b.Status == 1).OrderBy(a => a.CreatedAt).OrderBy(a => a.UpdatedAt).ToList();
                    bool IsAppNumberIsValid = false;
                    bool IsDocketNumber = false;
                    bool IsBoardOfNumber = false;
                    foreach (Form f in listOfForms)
                    {
                        if (f.Type == 1)
                        {
                            if (!string.IsNullOrEmpty(AppNumber))
                            {

                                var formsWithApp = dbcontext.IncarceratedStep1.Where(a => a.AplicationNumber == AppNumber && a.FormId == f.id).ToList();
                                if (formsWithApp != null)
                                {
                                    IsAppNumberIsValid = true;
                                    FilterfForms.Add(f);
                                }

                            }
                            if (!IsAppNumberIsValid && !string.IsNullOrEmpty(DocketNumber))
                            {
                                var formsWithApp = dbcontext.IncarceratedStep2.Where(a => a.ConvictDocket == AppNumber && a.FormId == f.id).ToList();
                                if (formsWithApp != null)
                                {
                                    IsDocketNumber = true;
                                    FilterfForms.Add(f);
                                }
                            }
                            if (!IsAppNumberIsValid && !string.IsNullOrEmpty(BoardOfNumber))
                            {
                                var formsWithApp = dbcontext.IncarceratedStep1.Where(a => a.PardonNumber == BoardOfNumber && a.FormId == f.id).ToList();
                                if (formsWithApp != null)
                                {
                                    IsDocketNumber = true;
                                    FilterfForms.Add(f);
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(DocketNumber))
                            {
                                var formsWithApp = dbcontext.NonIncarceratedStep2.Where(a => a.ConvictDocket == AppNumber && a.FormId == f.id).ToList();
                                if (formsWithApp != null)
                                {
                                    IsDocketNumber = true;
                                    FilterfForms.Add(f);
                                }
                            }
                        }
                    }
                    result = "";
                    isSuccess = true;
                    return FilterfForms;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                      new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return FilterfForms;
            }
        }
        public AllFormReview GetAllFormReview(int id, out string result, out bool isSuccess)
        {
            try
            {
                AllFormReview AllFormReview = new AllFormReview();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    AllFormReview.Id = id;
                    var form = dbcontext.Forms.Where(a => a.id == id).FirstOrDefault();
                    AllFormReview.type = form.Type;
                    if (form.Type == 2)
                    {
                        AllFormReview.IncarceratedStep1 = dbcontext.IncarceratedStep1.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep2 = dbcontext.IncarceratedStep2.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep3 = dbcontext.IncarceratedStep3.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep4 = dbcontext.IncarceratedStep4.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep5 = dbcontext.IncarceratedStep5.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep6 = dbcontext.IncarceratedStep6.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.IncarceratedStep7 = dbcontext.IncarceratedStep7.Where(a => a.FormId == id).FirstOrDefault();
                    }
                    else
                    {
                        AllFormReview.NonIncarceratedStep1 = dbcontext.NonIncarceratedStep1.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep2 = dbcontext.NonIncarceratedStep2.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep3 = dbcontext.NonIncarceratedStep3.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep4 = dbcontext.NonIncarceratedStep4.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep5 = dbcontext.NonIncarceratedStep5.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep6 = dbcontext.NonIncarceratedStep6.Where(a => a.FormId == id).FirstOrDefault();
                        AllFormReview.NonIncarceratedStep7 = dbcontext.NonIncarceratedStep7.Where(a => a.FormId == id).FirstOrDefault();
                    }
                    result = "";
                    isSuccess = true;
                    return AllFormReview;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                return null;
            }
        }
        public void updateFormReview(string command, string comment, int id, int currentReviewr, out string result, out bool isSuccess)
        {

            try
            {
                AllFormReview AllFormReview = new AllFormReview();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    var form = dbcontext.Forms.Where(a => a.id == id).FirstOrDefault();

                    if (command == "reject")
                        form.Status = 3;
                    else
                        form.Status = 4;

                    Review objReview = new Review();
                    objReview.Comment = comment;
                    objReview.FormId = id;
                    objReview.ReviewedAt = DateTime.Now;
                    objReview.ReviewerId = currentReviewr;
                    objReview.Status = form.Status;
                    dbcontext.Reviews.Add(objReview);
                    dbcontext.SaveChanges();
                    result = "";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
            }
        }

        //deactivate user
        public void DeactivateUser(int id, out string result, out bool isSuccess)
        {
            try
            {
                AllFormReview AllFormReview = new AllFormReview();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    var user = dbcontext.Users.Where(a => a.Id == id).FirstOrDefault();
                    user.Status = false;
                    dbcontext.SaveChanges();
                    result = "";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;

            }
        }
        //active user
        public void ActiveUser(int id, out string result, out bool isSuccess)
        {
            try
            {
                AllFormReview AllFormReview = new AllFormReview();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    var user = dbcontext.Users.Where(a => a.Id == id).FirstOrDefault();
                    user.Status = true;
                    dbcontext.SaveChanges();
                    result = "";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;

            }
        }

        public bool checkFormOwner(int formId, int userId)
        {
            try
            {
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    return dbcontext.Forms.Any(a => a.id == formId && a.UserId == userId);

                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                return false;
            }

        }

        public List<AllroleandUser> GetRolesOfUser(string username, out string result,out bool isSuccess)
        {
            List<AllroleandUser> listUser = new List<AllroleandUser>();
            try
            {
                string Query = @"SELECT U.UserName,ro.RoleName FROM Users U 
                                Left JOIN webpages_UsersInRoles WU on U.Id = WU.UserId 
                                Left JOIN webpages_Roles ro on WU.RoleId = ro.RoleId 
                                where U.UserName = '"+username+"'";
                List<User> list = new List<User>();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    listUser = dbcontext.Database.SqlQuery<AllroleandUser>(Query).ToList();
                    result = "";
                    isSuccess = true;
                    return listUser;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                         new StreamWriter(HostingEnvironment.MapPath("~/errLog.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }
                isSuccess = false;
                result = ex.Message;
                throw;
            } 
        }
    }
}