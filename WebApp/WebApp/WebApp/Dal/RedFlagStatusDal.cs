using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class RedFlagStatusDal
    {
        internal string Status(string PhoneNumber, string Status)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                var query = dbContext.LoanDetails

                .Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                query.LoanStatus = Status;
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