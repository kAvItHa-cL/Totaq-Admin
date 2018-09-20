using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class UserDetailsDetailDal
    {
        internal Register GetUserInformation(string PhoneNumber)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                var query = dbContext.Registers

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