using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class RedFlagDal
    {
        internal List<Register> GetRedFlagDetail()
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.Registers

                .Where(t => t.LoanDetails.Any(y => y.DueDate.Day <= DateTime.Now.Day && y.DueDate.Month <= DateTime.Now.Month && y.DueDate.Year <= DateTime.Now.Year))
                .ToList<Register>();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}