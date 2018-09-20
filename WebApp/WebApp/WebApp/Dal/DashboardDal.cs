using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dal
{
    public class DashboardDal
    {
        GTLOANEntities dbcontext = new GTLOANEntities();
        public int GetUserCount()
        {
            try
            {
                int user = dbcontext.Registers.Count();
                return user;

            }
            catch(Exception ex)
            {
                throw;
            }

        }
        public decimal GetLoanDisperse()
        {

            try
            {

                int count = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Active").Count();
                if (count > 0)
                {
                    decimal LoanAmount = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Active").Sum(l => l.LoanAmount);

                    if (LoanAmount > 0)
                        return LoanAmount;
                    else return 0;
                }
                else return 0;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public decimal GetLoanPending ()
        {
            try
            {
                int count = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Pending").Count();
                if (count > 0)
                {
                    decimal LoanPending = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Pending").Sum(l => l.LoanAmount);
                    if (LoanPending > 0)
                        return LoanPending;
                    else return 0;
                }
                else return 0;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public decimal GetRedFlags ()
        {
            return 0;
        }
        public decimal GetTotalRevenue ()
        {

            try
            {
                int count  = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Active" || l.LoanStatus == "Settled").Count(); ;
                if (count > 0)
                {
                    decimal TotalRevenue = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Active" || l.LoanStatus == "Settled").Sum(l => l.LoanAmount);
                    if (TotalRevenue > 0)
                        return TotalRevenue;
                    else return 0;
                }
                else return 0;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public decimal GetTotalSettlement()
        {

            try
            {
                int  count  = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Settled").Count();
                if (count > 0)
                {
                    decimal Settlement = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Settled").Sum(l => l.LoanAmount);
                    if (Settlement > 0)
                        return Settlement;
                    else return 0;
                }
                else return 0;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public decimal GetTotalProfit()
        {
            try
            {
                decimal SettledAmount, SettledFee;
                int loancount = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Settled").Count();
                if (loancount > 0)
                {
                     SettledAmount = dbcontext.LoanDetails.Where(l => l.LoanStatus == "Settled").Sum(l => l.LoanAmount);
                }
                else
                {
                     SettledAmount = 0;
                }

                int feecount = dbcontext.OneTimeFees.Where(l => l.Status == "Settled").Count();
                if (feecount > 0)
                {
                     SettledFee = (decimal)dbcontext.OneTimeFees.Where(l => l.Status == "Settled").Sum(l => l.Fee);
                }
                else
                {
                     SettledFee = 0;
                }
                if (SettledAmount > 0)
                {
                    decimal InterestAmount = SettledAmount * 3 / 100;
                    decimal Profit = InterestAmount + SettledFee;
                    if (Profit > 0)
                        return Profit;
                    else return 0;
                }
                else
                {
                    decimal Profit = SettledFee;
                    return Profit;
                }
               
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public decimal GetOneTimeFee()
        {
            try
            {
                int count = dbcontext.OneTimeFees.Where(l => l.Status == "Settled").Count();
                if (count > 0)
                {
                    decimal Settlement = (decimal)dbcontext.OneTimeFees.Where(l => l.Status == "Settled").Sum(l => l.Fee);
                    if (Settlement > 0)
                        return Settlement;
                    else return 0;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}