using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class LoanDetailsDal
    {
        internal BasicDetail GetBasicDetail(string PhoneNumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.BasicDetails
                .Where(p => p.PhoneNumber == PhoneNumber)
                .FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal LoanDetail GetLoanDetail(string PhoneNumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.LoanDetails
                .Where(p => p.PhoneNumber == PhoneNumber && p.LoanStatus.ToLower()=="pending")
                .FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal ProfessionalDetail GetProfessionalDetail(string PhoneNumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.ProfessionalDetails
                .Where(p => p.PhoneNumber == PhoneNumber)
                .FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}