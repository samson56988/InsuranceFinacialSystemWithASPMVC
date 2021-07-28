using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanFinancialSoftware.Models.FinancialAnalysis
{
    public class PersonalLoanFinancialAnalysis
    {
        public int ApplicationID {get; set;}

        public decimal PrincipalLoan {get; set;}

        public int LoanTerm { get; set; }

        public decimal IntrestRate {get; set;}

        public int Regno { get; set; }


    }
}