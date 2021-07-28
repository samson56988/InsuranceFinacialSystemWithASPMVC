using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LoanFinancialSoftware.Config
{
    public class StoreConnections
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["LoanErpSystem"].ConnectionString;
        }
    }
}