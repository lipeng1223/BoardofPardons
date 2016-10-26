using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using System.IO;
using System.Web.Hosting;
using BoardofPardons.Entity;

namespace BoardofPardons.Models
{
    public class InCarceratedManger
    {
        public IncarceratedStep1 insertStep1(IncarceratedStep1 step1, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form.CreatedAt = DateTime.Now;
                    form.UserId = userid;
                    form.Type = 2;
                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }

                    form = dbcontext.Forms.Add(form);
                    dbcontext.SaveChanges();
                    step1.CreatedAt = DateTime.Now;

                    step1.FormId = form.id;
                    step1 = dbcontext.IncarceratedStep1.Add(step1);
                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step1;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep1 getIncarceratedStep1(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep1.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep2 insertStep2(IncarceratedStep2 step2, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form = dbcontext.Forms.Where(a => a.id == step2.FormId).FirstOrDefault();

                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }


                    var _step2 = dbcontext.IncarceratedStep2.Where(a => a.FormId == step2.FormId).FirstOrDefault();
                    if (_step2 == null)
                    {
                        step2.CreatedAt = DateTime.Now;
                        step2 = dbcontext.IncarceratedStep2.Add(step2);
                    }
                    else
                    {
                        _step2 = step2;
                        _step2.UpdatedAt = DateTime.Now;
                    }


                    //step2.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step2;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep2 getIncarceratedStep2(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep2.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep3 insertStep3(IncarceratedStep3 step3, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form = dbcontext.Forms.Where(a => a.id == step3.FormId).FirstOrDefault();

                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }

                    var _step3 = dbcontext.IncarceratedStep3.Where(a => a.FormId == step3.FormId).FirstOrDefault();
                    if (_step3 == null)
                    {
                        step3.CreatedAt = DateTime.Now;
                        step3 = dbcontext.IncarceratedStep3.Add(step3);
                    }
                    else
                    {
                        _step3 = step3;
                        _step3.UpdatedAt = DateTime.Now;
                    }


                    //step3.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step3;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep3 getIncarceratedStep3(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep3.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep4 insertStep4(IncarceratedStep4 step4, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form = dbcontext.Forms.Where(a => a.id == step4.FormId).FirstOrDefault();
                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }


                    var _step4 = dbcontext.IncarceratedStep4.Where(a => a.FormId == step4.FormId).FirstOrDefault();
                    if (_step4 == null)
                    {
                        step4.CreatedAt = DateTime.Now;
                        step4 = dbcontext.IncarceratedStep4.Add(step4);
                    }
                    else
                    {
                        _step4 = step4;
                        _step4.UpdatedAt = DateTime.Now;
                    }


                    //step4.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step4;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep4 getIncarceratedStep4(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep4.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep5 insertStep5(IncarceratedStep5 step5, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {
                    form = dbcontext.Forms.Where(a => a.id == step5.FormId).FirstOrDefault();

                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }


                    var _step5 = dbcontext.IncarceratedStep5.Where(a => a.FormId == step5.FormId).FirstOrDefault();
                    if (_step5 == null)
                    {
                        step5.CreatedAt = DateTime.Now;
                        step5 = dbcontext.IncarceratedStep5.Add(step5);
                    }
                    else
                    {
                        _step5 = step5;
                        _step5.UpdatedAt = DateTime.Now;
                    }


                    //step5.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step5;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep5 getIncarceratedStep5(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep5.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep6 insertStep6(IncarceratedStep6 step6, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form = dbcontext.Forms.Where(a => a.id == step6.FormId).FirstOrDefault();

                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }



                    var _step6 = dbcontext.IncarceratedStep6.Where(a => a.FormId == step6.FormId).FirstOrDefault();
                    if (_step6 == null)
                    {
                        step6.CreatedAt = DateTime.Now;
                        step6 = dbcontext.IncarceratedStep6.Add(step6);
                    }
                    else
                    {
                        _step6 = step6;
                        _step6.UpdatedAt = DateTime.Now;
                    }


                    //step6.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step6;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep6 getIncarceratedStep6(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep6.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
        public IncarceratedStep7 insertStep7(IncarceratedStep7 step7, int userid, string Command, out string result, out bool isSuccess)
        {
            try
            {
                Form form = new Form();
                using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
                {

                    form = dbcontext.Forms.Where(a => a.id == step7.FormId).FirstOrDefault();
                    if (Command == "save")
                    {
                        form.Status = 0;
                    }
                    else
                    {
                        form.Status = 1;
                    }

                    var _step7 = dbcontext.IncarceratedStep7.Where(a => a.FormId == step7.FormId).FirstOrDefault();
                    if (_step7 == null)
                    {
                        step7.CreatedAt = DateTime.Now;
                        step7 = dbcontext.IncarceratedStep7.Add(step7);
                    }
                    else
                    {
                        _step7 = step7;
                        _step7.UpdatedAt = DateTime.Now;
                    }


                    //step7.FormId = form.id;

                    dbcontext.SaveChanges();
                }
                isSuccess = true;
                result = "Success";
                return step7;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                            new StreamWriter(HostingEnvironment.MapPath("errLog.txt")))
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
        public IncarceratedStep7 getIncarceratedStep7(int formId)
        {
            using (BoardofPardonsEntities1 dbcontext = new BoardofPardonsEntities1())
            {
                return dbcontext.IncarceratedStep7.Where(a => a.FormId == formId).FirstOrDefault();
            }
        }
    }
}