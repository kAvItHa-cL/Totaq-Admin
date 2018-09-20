using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        List<BasicDetail> model = new List<BasicDetail>();
        RegisterDal objRegister = new RegisterDal();
      //  UserInformationDal objuserinfo = new UserInformationDal();
       ApproveRegistrationDal approve = new ApproveRegistrationDal();
        // GET: Register
        public ActionResult Register()
        {
            model = objRegister.GetRegisterList();
            return View(model);
        }

        public ActionResult Details(long id)
        {
            Register model = new Register();
            UserDetailsDetailDal objuserinfo = new UserDetailsDetailDal();
            model = objuserinfo.GetUserInformation(id.ToString());
            return View(model);
        }
        [HttpPost]
        public ActionResult ApproveLoan(string PhoneNumber,string Title , string Message)
        {
            
            try
            {
                Notification notify = new Notification();
                notify.PhoneNumber = PhoneNumber;
                notify.Title = Title;
                notify.Message = Message;
                notify.Date = DateTime.Now;
                string send = approve.SendNotification(notify);
                string response = approve.Approve(PhoneNumber);
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
                Notification notify = new Notification();
                notify.PhoneNumber = PhoneNumber;
                notify.Title = Title;
                notify.Message = Message;
                notify.Date = DateTime.Now;
                string send = approve.SendNotification(notify);
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