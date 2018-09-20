using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class RedFlagController : Controller
    {
        RedFlagDal objred = new RedFlagDal();
        LoanDetail pay = new LoanDetail();
        RedFlagStatusDal status = new RedFlagStatusDal();
        public ActionResult RedFlag()
        {
            List<Register> model = new List<Register>();
            model = objred.GetRedFlagDetail();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangeUserStatus(string PhoneNumber, string Status)
        {
            try
            {
                pay.LoanStatus = Status;
                string response = status.Status(PhoneNumber, Status);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("Error");
                throw;
            }
        }
    }
}