using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class NewLoanApplicationDal
    {
        internal List<LoanDetail> GetNewLoanApplicationDetails()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.LoanDetails
                .ToList<LoanDetail>();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}