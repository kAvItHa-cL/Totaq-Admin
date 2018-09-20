using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PaymentsController : Controller
    {
        PaymentsDal objpay = new PaymentsDal();
        PaymentModel model = new PaymentModel();
        LoanDetail loanModel = new LoanDetail();
        List<LoanDetail> listModel = new List<LoanDetail>();

        public ActionResult Payment()
        {

            //model.BasicDetail = objpay.GetBasicDetail();
            //model.LoanDetail = objpay.GetLoanDetail();
            listModel = objpay.GetLoanList();
            return View(listModel);
        }

        [HttpPost]
        public ActionResult ChangeStatus(string PhoneNumber, string Status)
        {
            try
            {
                //loanModel.LoanStatus = Status;
                if(Status!= "Active")
                {
                    objpay.UpdateStatus(PhoneNumber, Status);
                }
                else
                {
                    //Send Notification
                }              
                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json("Error");
                throw;
            }

        }

    }
}