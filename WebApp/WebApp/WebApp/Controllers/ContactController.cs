using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        UserContact model = new UserContact();
        UserContactDal objcon = new UserContactDal();
        public ActionResult Contact()
        {
            List<UserContact> model = new List<UserContact>();
            model = objcon.GetUserContactDetails();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangeUserContactUs(string PhoneNumber, string Status)
        {
            try
            {

                model.Status = Status;
                string response = objcon.Status(PhoneNumber, Status);
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