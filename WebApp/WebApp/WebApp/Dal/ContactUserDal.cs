using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApp.Dal
{
    public class ContactUserDal
    {
        internal void SendMail(string EmailId, string Message)
        {
            try
            {

                using (MailMessage mailMessage = new MailMessage())
                {
                    string body = Message;
                    mailMessage.From = new MailAddress("support@eventserica.com");
                    mailMessage.Subject = "Enquery From Totaq Admin";
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(EmailId));
                    var SmtpClient = new SmtpClient();
                    SmtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal string AddMailMessage(ContactUser model)
        {
            try
            {

                GTLOANEntities dbcontext = new GTLOANEntities();
                dbcontext.ContactUsers.Add(model);
                dbcontext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal List<BasicDetail> GetUserName(string EmailId)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                if (EmailId == "All")
                {
                    var queryAll = dbContext.BasicDetails

                   .ToList<BasicDetail>();
                    return queryAll;
                }

                var query = dbContext.BasicDetails
                    .Where(p => p.EmailId == EmailId).ToList<BasicDetail>();
                return query;

            }

            catch (Exception ex)
            {
                throw;
            }


        }
        internal List<BasicDetail> GetOrganiserUsername()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.BasicDetails.ToList<BasicDetail>();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}