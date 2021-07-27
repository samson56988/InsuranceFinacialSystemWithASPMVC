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

        public string LoanTerm { get; set; }

        public int IntrestRate {get; set;}

        public string RepaymentSchedule {get; set;}

        public decimal RepaymentAmount {get; set;}

        public decimal TotalRepaymentAmount {get; set;}
    }
}