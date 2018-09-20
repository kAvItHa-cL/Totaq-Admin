using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OneTimePaymentController : Controller
    {
        // GET: OneTimePayment
        public ActionResult OneTimePay()
        {
            return View();
        }
    }
}