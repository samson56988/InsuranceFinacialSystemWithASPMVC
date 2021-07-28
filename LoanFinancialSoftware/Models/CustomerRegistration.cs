using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanFinancialSoftware.Models
{
    public class CustomerRegistration
    {
        public string Firstname { get; set; }

        public string Secondname { get; set; }

        public  string Lastname { get; set; }

        public string Country { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}