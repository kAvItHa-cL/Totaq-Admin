using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;

namespace WebApp.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn(string EmailId, string Password)
        {
            try
            {
                AdminLogin model = new AdminLogin();
                SignInDal objUser = new SignInDal();
                model.Username = EmailId;
                model.Password = Password;
                string response = objUser.checklogin(model);
                if (response == "success")
                {
                    Session["Username"] = EmailId;
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (response == "False")
                {
                    ViewBag.LoginError = "Invalid credentials, Please try again!";
                    return View();
                }
                else
                {
                    ViewBag.LoginError = "Please fill all the fields";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

           

        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("SignIn", "SignIn");
        }

    }

}