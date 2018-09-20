using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PaymentModel
    {
        public LoanDetail LoanDetail { get; set; }
        public BasicDetail BasicDetail { get; set; }
    }
}