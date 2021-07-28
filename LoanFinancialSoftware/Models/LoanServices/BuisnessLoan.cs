using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanFinancialSoftware.Models.LoanServices
{
    public class BuisnessLoan
    {
        public string Fullname { get; set; }

        public int ApplicationNo { get; set; }

        public int Regno { get; set; }

        public decimal AnnualRevenue { get; set;}

        public string BankStatement { get; set; }

        public decimal loanAmount { get; set; }

        public decimal BuisnessTaxReturn { get; set; }

        public string BuisnessPlan { get; set; }

        public string CollateralName { get; set; }

        public decimal CollateralWorth { get; set; }

        public string GovermentID { get; set; }

        public string BuisnessLicencesDocuments { get; set; }

        public string BankName { get; set; }

        public int bankAccount { get; set; }

        public HttpPostedFileBase BankStatementFile { get; set; }

        public HttpPostedFileBase GoverementIDFile { get; set; }

        public HttpPostedFileBase BuisnessPlanDOC { get; set; }

        public HttpPostedFileBase businesslicenseDoc { get; set; }

    }
}