using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class LoanApplicationController : Controller
    {
       
        NewLoanApplicationDal objloan = new NewLoanApplicationDal();
        
        public ActionResult LoanApplication()
        {
            List<LoanDetail> model = new List<LoanDetail>();
            model = objloan.GetNewLoanApplicationDetails();
            return View(model);
        }
    }
}