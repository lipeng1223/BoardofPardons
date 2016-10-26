using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;

namespace BoardofPardons.Models
{
    public class Utility
    {

        public static string GetUserID()
        {
            MembershipUser _User;
            string _UserId = "";
            _User = Membership.GetUser();
            Guid UserId = (Guid)_User.ProviderUserKey;
            return _UserId = UserId.ToString();
        }

        public static void sendSubmitEmail(List<string> ToEmail, string name, string subject, string msg)
        {
            try
            {
                string emailEnqueryBody = "@name <br/> @subject <br/> @msg <br/>";
                foreach (string toEmail in ToEmail)
                {
                    System.Net.Mail.MailMessage tMailMessage = new System.Net.Mail.MailMessage();
                    //Assign sender email address
                    tMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["senderEmail"].ToString(), ConfigurationManager.AppSettings["displayName"].ToString());
                    //Assign recipient email address
                    tMailMessage.To.Add(toEmail);
                    //Assign the subject 
                    tMailMessage.Subject = "New Form Submited";
                    //Assign the mail body
                    tMailMessage.Body = emailEnqueryBody.Replace("@name", name).Replace("@subject", subject).Replace("@msg", msg);
                    //assign the format of the mail body
                    tMailMessage.IsBodyHtml = true;
                    // Assign the priority of the mail message to normal
                    tMailMessage.Priority = System.Net.Mail.MailPriority.High;

                    //Subject encoding by UTF-8
                    tMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    //Body encoding by UTF-8
                    tMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    //Create a new instance of SMTP client and pass name and port number         
                    //of the smtp gmail server 
                    SmtpClient tSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["host"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["port"]));
                    //Enable SSL of the SMTP client
                    tSmtpClient.EnableSsl = false;
                    //Use delivery method as network
                    tSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //Use DefaultCredentials set to false
                    tSmtpClient.UseDefaultCredentials = false;
                    //Pass account information of the sender
                    tSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["senderEmail"].ToString(), ConfigurationManager.AppSettings["senderPassWord"].ToString());
                    tSmtpClient.Send(tMailMessage);
                    msg = "true";

                }


            }
            catch (Exception ex)
            {
                using (StreamWriter writer =
                    new StreamWriter(HostingEnvironment.MapPath("important.txt")))
                {
                    writer.WriteLine("==========================");
                    writer.WriteLine("Date " + DateTime.Now);
                    writer.WriteLine("Error" + ex.Message);

                }

            }
        }
        public static void sendReviewEmail(string ToEmail, string subject, string msg)
        {
            try
            {
                string emailEnqueryBody = "@subject <br/> @msg <br/>";
                    System.Net.Mail.MailMessage tMailMessage = new System.Net.Mail.MailMessage();
                    //Assign sender email address
                    tMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["senderEmail"].ToString(), ConfigurationManager.AppSettings["displayName"].ToString());
                    //Assign recipient email address
                    tMailMessage.To.Add(ToEmail);
                    //Assign the subject 
                    tMailMessage.Subject = "New Form Submited";
                    //Assign the mail body
                    tMailMessage.Body = emailEnqueryBody.Replace("@subject", subject).Replace("@msg", msg);
                    //assign the format of the mail body
                    tMailMessage.IsBodyHtml = true;
                    // Assign the priority of the mail message to normal
                    tMailMessage.Priority = System.Net.Mail.MailPriority.High;

                    //Subject encoding by UTF-8
                    tMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    //Body encoding by UTF-8
                    tMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    //Create a new instance of SMTP client and pass name and port number         
                    //of the smtp gmail server 
                    SmtpClient tSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["host"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["port"]));
                    //Enable SSL of the SMTP client
                    tSmtpClient.EnableSsl = false;
                    //Use delivery method as network
                    tSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //Use DefaultCredentials set to false
                    tSmtpClient.UseDefaultCredentials = false;
                    //Pass account information of the sender
                    tSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["senderEmail"].ToString(), ConfigurationManager.AppSettings["senderPassWord"].ToString());
                    tSmtpClient.Send(tMailMessage);
                    msg = "true";

                

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

            }
        }

    }
}