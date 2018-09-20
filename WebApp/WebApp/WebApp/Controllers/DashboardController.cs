using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Dal;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        DashboardDal objDashboard = new DashboardDal();
        DashboardModel model = new DashboardModel();

        // GET: Dashboard
        public ActionResult Index()
        {
            int UserCount = objDashboard.GetUserCount();
            int LoanDisperse = (int)objDashboard.GetLoanDisperse();
            int LoanPending = (int)objDashboard.GetLoanPending();
            int RedFlags = (int)objDashboard.GetRedFlags();
            int TotalRevenue = (int)objDashboard.GetTotalRevenue();
            int TotalSettled = (int)objDashboard.GetTotalSettlement();
            int Profit = (int)objDashboard.GetTotalProfit();
            int OneTimeFee = (int)objDashboard.GetOneTimeFee();

            model.UserCount = UserCount;
            model.LoanDisperse = LoanDisperse;
            model.LoanPending = LoanPending;
            model.RedFlags = RedFlags;
            model.TotalRevenue = TotalRevenue;
            model.TotalSettled = TotalSettled;
            model.Profit = Profit;
            model.OneTimeFee = OneTimeFee;
             return View(model);
        }
    }
}