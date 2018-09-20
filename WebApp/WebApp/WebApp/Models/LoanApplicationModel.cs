using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class LoanApplicationModel
    {
        public LoanDetail LoanDetail { get; set; }
        public ProfessionalDetail ProfessionalDetail { set; get; }
        public BasicDetail BasicDetail { get; set; }
    }
}