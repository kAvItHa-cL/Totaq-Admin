using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class ApproveRegistrationDal
    {
        internal string Approve(string PhoneNumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                var query = dbContext.Registers

                    .Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();

                query.Status = "Active";

                dbContext.Entry(query).State = EntityState.Modified;
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        internal string DisApprove(string Phonenumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                var query = dbContext.Registers

                    .Where(p => p.PhoneNumber == Phonenumber).FirstOrDefault();

                query.Status = "rejected";
                dbContext.Entry(query).State = EntityState.Modified;
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        internal string SendNotification(Notification notify)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                dbContext.Notifications.Add(notify);
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
}