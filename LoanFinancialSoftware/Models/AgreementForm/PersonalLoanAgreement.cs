using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanFinancialSoftware.Models.AgreementForm
{
    public class PersonalLoanAgreement
    {
        public int ApplicationID { get; set; }

        public decimal PrincipalLoan { get; set; }

        public int LoanTerm { get; set; }

        public decimal IntrestRate { get; set; }

        public decimal TotalIntrest { get; set; }

        public decimal RepaymentAmount { get; set; }

        public decimal TotalDailyIntrest { get; set; }

        public decimal TotalRepaymentAmount { get; set; }

        public int Regno { get; set; }

        public string HouseAddress { get; set; }
        
        public string Firstname { get; set; }

        public string lastname { get; set; }

        public string EmailID { get; set; }

      
        public DateTime  PaymentDueDate { get; set; }

        public Decimal AmountPaid { get; set; }

        public string Isdue { get; set; }



        

    }
}