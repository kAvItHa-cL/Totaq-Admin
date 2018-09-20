using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class ContactUserController : Controller
    {
        ContactUserDal objcon = new ContactUserDal();
        List<BasicDetail> list = new List<BasicDetail>();
        public ActionResult ContactUser()
        {
            string EmailId = "All";
            list = objcon.GetUserName(EmailId);
            return View(list);
        }
        [HttpPost]
        public ActionResult SendMail(string Emailid, string Message)
        {
            ContactUser objcontact = new ContactUser();
            objcontact.EmailId = Emailid;
            objcontact.Message = Message;
            objcon.AddMailMessage(objcontact);
            objcon.SendMail(Emailid, Message);
            return View();
        }
        public JsonResult UsernameSelectList()
        {
            List<String> Usernamelist = new List<string>();

            list = objcon.GetOrganiserUsername();

            foreach (var item in list)
            {
                Usernamelist.Add(item.EmailId);
            }

            return Json(Usernamelist, JsonRequestBehavior.AllowGet);
        }

    }
}