using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class SignInDal
    {
        internal string checklogin(AdminLogin model1)
        {
            try
            {
                GTLOANEntities dbContext = new GTLOANEntities();
                if (model1.Username != "" && model1.Password != "")
                {
                    var loginresult = dbContext.AdminLogins.Where(s => s.Username == model1.Username && s.Password == model1.Password).FirstOrDefault();
                    if (loginresult != null)
                    {
                        return "success";
                    }
                    else
                    {
                        return "False";
                    }
                }
                else return "empty";
            }
            catch (Exception)
            {
                return "False";
                throw;
            }
        }
    }
}