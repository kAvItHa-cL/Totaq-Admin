using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class OneTimeProccessingFeeController : Controller
    {
        OneTimeProcessingFeeDal objpro = new OneTimeProcessingFeeDal();
        OneTimeFee objfee = new OneTimeFee();

        public ActionResult OneTimeProccessingFee()
        {
            List<Register> model = new List<Register>();
            model = objpro.GetPaymentsDetail();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangeOneTimeFeeStatus(string PhoneNumber, string Status)
        {
            try
            {
                objfee.Status = Status;

                string response = objpro.Status(PhoneNumber, Status);
                if (Status == "Not Paid")
                {
                    ApproveRegistrationDal apd = new ApproveRegistrationDal();
                    Notification notify = new Notification();
                    notify.PhoneNumber = PhoneNumber;
                    notify.Title = "NotPaid";
                    notify.Message = "One Time Processing Fee is not Paid so loan status is Pending ";
                    notify.Date = DateTime.Now;
                    string send = apd.SendNotification(notify);
                }
                else
                 if (Status == "Paid")
                {
                    ApproveRegistrationDal apd = new ApproveRegistrationDal();
                    Notification notify = new Notification();
                    notify.PhoneNumber = PhoneNumber;
                    notify.Title = "NotPaid";
                    notify.Message = "One Time Processing Fee is Paid ";
                    notify.Date = DateTime.Now;
                    string send = apd.SendNotification(notify);
                }

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