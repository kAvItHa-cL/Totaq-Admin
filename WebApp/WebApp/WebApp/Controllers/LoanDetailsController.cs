using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoanDetailsController : Controller
    {
        LoanDetailsDal objloan = new LoanDetailsDal();
        LoanApproval approve = new LoanApproval();
        LoanApplicationModel model = new LoanApplicationModel();

        public ActionResult LoanDetails(string id)
        {
            model.BasicDetail = objloan.GetBasicDetail(id);
            model.LoanDetail = objloan.GetLoanDetail(id);
            model.ProfessionalDetail = objloan.GetProfessionalDetail(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult ApproveLoan(string PhoneNumber, string Transaction, string Title, string Message)
        {
            try
            {
                ApproveRegistrationDal apd = new ApproveRegistrationDal();
                Notification notify = new Notification();
                notify.PhoneNumber = PhoneNumber;
                notify.Title = Title;
                notify.Message = Message;
                notify.Date = DateTime.Now;
                string send = apd.SendNotification(notify);
                string response = approve.Approve(PhoneNumber, Transaction);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("Error");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DisApproveLoan(string PhoneNumber, string Title, string Message)
        {
            try
            {
                ApproveRegistrationDal apd = new ApproveRegistrationDal();
                Notification notify = new Notification();
                notify.PhoneNumber = PhoneNumber;
                notify.Title = Title;
                notify.Message = Message;
                notify.Date = DateTime.Now;
                string send = apd.SendNotification(notify);
                string response = approve.DisApprove(PhoneNumber);
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