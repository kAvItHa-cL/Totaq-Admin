using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class LoanApproval
    {
        internal string Approve(string PhoneNumber, string Transaction)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();

                var query = dbContext.LoanDetails

                    .Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();

                query.LoanStatus = "Active";
                query.DueDate = DateTime.Now.AddDays(+14);
                query.LoanTransactionNo = Transaction;
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

                var query = dbContext.LoanDetails

                    .Where(p => p.PhoneNumber == Phonenumber).FirstOrDefault();

                query.LoanStatus = "Rejected";
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