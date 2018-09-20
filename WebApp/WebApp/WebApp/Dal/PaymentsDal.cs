using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class PaymentsDal
    {
        internal BasicDetail GetBasicDetail()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.BasicDetails
                .FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal LoanDetail GetLoanDetail()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.LoanDetails
                     .Where(e => e.LoanStatus == "Active")
                .FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal List<LoanDetail> GetLoanList()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.LoanDetails
                     .Where(e => e.LoanStatus == "Active")
                .ToList<LoanDetail>();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal void UpdateStatus(string phoneNumber, string status)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.LoanDetails
                    .Where(e => e.LoanStatus == "Active")
                .FirstOrDefault();
                query.LoanStatus = status;
                dbContext.Entry(query).State = EntityState.Modified;
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}