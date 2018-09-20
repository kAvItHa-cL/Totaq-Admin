using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class UserContactDal
    {
        internal List<UserContact> GetUserContactDetails()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.UserContacts
                 .ToList<UserContact>();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal string Status(string PhoneNumber, string Status)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                var query = dbContext.UserContacts

                .Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                query.Status = Status;
                dbContext.Entry(query).State = EntityState.Modified;
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}