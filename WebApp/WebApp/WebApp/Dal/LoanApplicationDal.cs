using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class LoanApplicationDal
    {
        GTLOANEntities context = new GTLOANEntities();
        internal List<LoanDetail> GetLoanList()
        {
            try
            {
                var list = context.LoanDetails.ToList<LoanDetail>();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}