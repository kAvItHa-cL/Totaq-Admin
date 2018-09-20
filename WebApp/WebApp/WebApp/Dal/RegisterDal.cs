using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class RegisterDal
    {
        GTLOANEntities context = new GTLOANEntities();
        internal List<BasicDetail> GetRegisterList()
        {
            try
            {
                var list = context.BasicDetails.ToList<BasicDetail>();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}