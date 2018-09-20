using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class DashboardModel
    {
        public int UserCount { get; set; }
        public decimal? LoanDisperse { get; set; }
        public decimal LoanPending { get; set; }
        public decimal RedFlags { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalSettled { get; set; }
        public decimal Profit { get; set; }
        public decimal OneTimeFee { get; set; }

    }
}