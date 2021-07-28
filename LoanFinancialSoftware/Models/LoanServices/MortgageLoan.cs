using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanFinancialSoftware.Models.LoanServices
{
    public class MortgageLoan
    {
        public string Fullname { get; set; }

        public int ApplicationNo { get; set; }

        public int RegistrationNo { get; set; }

        public string Occupation { get; set; }

        public string MaritalStatus { get; set; }

        public decimal MonthlyIncome { get; set; }

        public string BankStatement { get; set; }

        public decimal LoanAmount { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string HouseAddress { get; set; }

        public string GovermentID { get; set; }

        public string MortgageType { get; set; }

        public string CollateralName { get; set; }

        public decimal CollateralWorth { get; set; }

        public string BankName { get; set; }

        public int BankAccount { get; set; }

        public HttpPostedFileBase BankStatementFile { get; set; }

        public HttpPostedFileBase GoverementIDFile { get; set; }
    }
}