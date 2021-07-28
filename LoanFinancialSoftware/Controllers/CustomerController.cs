using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanFinancialSoftware.Models.LoanServices;
using System.Data.SqlClient;
using LoanFinancialSoftware.Config;
using System.Data;
using System.IO;
using LoanFinancialSoftware.Models.AgreementForm;
namespace LoanFinancialSoftware.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Username"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        public ActionResult AutoLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AutoLoanApplication(AutoLoan auto)
        {
            
            string filename = Path.GetFileNameWithoutExtension(auto.BankStatementFile.FileName);
            string extension = Path.GetExtension(auto.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            auto.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            auto.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(auto.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(auto.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            auto.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            auto.GoverementIDFile.SaveAs(filename2);

            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
               
                string Username = (string)Session["Username"];
                List<AutoLoan> loan = new List<AutoLoan>();
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        auto.RegistrationNo = Convert.ToInt32(row["RegistrationID"].ToString());

                            
                            
                    };

                    con.Close();

                }

                using (SqlCommand cmd = new SqlCommand("insertautoLoan", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", auto.RegistrationNo);
                    cmd.Parameters.AddWithValue("@Occupation", auto.Occupation);
                    cmd.Parameters.AddWithValue("@MaritalStatus", auto.MaritalStatus);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", auto.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@BankStatement", auto.BankStatement);
                    cmd.Parameters.AddWithValue("@LoanAmount", auto.LoanAmount);
                    cmd.Parameters.AddWithValue("@CompanyName", auto.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", auto.CompanyAddress);
                    cmd.Parameters.AddWithValue("@HouseAddress", auto.HouseAddress);
                    cmd.Parameters.AddWithValue("@GovermentID", auto.GovermentID);
                    cmd.Parameters.AddWithValue("@collateralName", auto.CollateralName);
                    cmd.Parameters.AddWithValue("@CollateralWorth", auto.CollateralWorth);
                    cmd.Parameters.AddWithValue("@BankName", auto.BankName);
                    cmd.Parameters.AddWithValue("@BankAccount", auto.BankAccount);
                    cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }

        }

        public ActionResult PersonalLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
            return View();
        }

        [HttpPost]
        public ActionResult PersonalLoanApplication(PersonalLoan person)
        {
            string filename = Path.GetFileNameWithoutExtension(person.BankStatementFile.FileName);
            string extension = Path.GetExtension(person.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            person.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            person.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(person.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(person.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            person.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            person.GoverementIDFile.SaveAs(filename2);
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                string Username = (string)Session["Username"];
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        person.RegistrationNo = Convert.ToInt32(row["RegistrationID"].ToString());



                    };

                    con.Close();

                }
                using (SqlCommand cmd = new SqlCommand("PersonalLoanApplication", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", person.RegistrationNo);
                    cmd.Parameters.AddWithValue("@Occupation", person.Occupation);
                    cmd.Parameters.AddWithValue("@MaritalStatus", person.MaritalStatus);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", person.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@BankStatement", person.BankStatement);
                    cmd.Parameters.AddWithValue("@LoanAmount", person.LoanAmount);
                    cmd.Parameters.AddWithValue("@CompanyName", person.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", person.CompanyAddress);
                    cmd.Parameters.AddWithValue("@HouseAddress", person.HouseAddress);
                    cmd.Parameters.AddWithValue("@GovermentID", person.GovermentID);
                    cmd.Parameters.AddWithValue("@collateralName", person.CollateralName);
                    cmd.Parameters.AddWithValue("@CollateralWorth", person.CollateralWorth);
                    cmd.Parameters.AddWithValue("@BankName", person.BankName);
                    cmd.Parameters.AddWithValue("@BankAccount", person.BankAccount);
                    cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }

            
        }

        public ActionResult PayDayLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }
           
            return View();
        }

        [HttpPost]
        public ActionResult PayDayLoanApplication(PayDayLoan payday)
        {
            string filename = Path.GetFileNameWithoutExtension(payday.BankStatementFile.FileName);
            string extension = Path.GetExtension(payday.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            payday.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            payday.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(payday.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(payday.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            payday.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            payday.GoverementIDFile.SaveAs(filename2);

            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                string Username = (string)Session["Username"];
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        payday.RegistrationNo = Convert.ToInt32(row["RegistrationID"].ToString());



                    };

                    con.Close();

                }
                using (SqlCommand cmd = new SqlCommand("insertPaydayApplication", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", payday.RegistrationNo);
                    cmd.Parameters.AddWithValue("@Occupation", payday.Occupation);
                    cmd.Parameters.AddWithValue("@MaritalStatus", payday.MaritalStatus);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", payday.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@BankStatement", payday.BankStatement);
                    cmd.Parameters.AddWithValue("@LoanAmount", payday.LoanAmount);
                    cmd.Parameters.AddWithValue("@CompanyName", payday.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", payday.CompanyAddress);
                    cmd.Parameters.AddWithValue("@HouseAddress", payday.HouseAddress);
                    cmd.Parameters.AddWithValue("@GovermentID", payday.GovermentID);
                    cmd.Parameters.AddWithValue("@BankName", payday.BankName);
                    cmd.Parameters.AddWithValue("@BankAccount", payday.BankAccount);
                    cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }
        }

        public ActionResult MortgageLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        [HttpPost]
        public ActionResult MortgageLoanApplication(MortgageLoan mortgage)
        {
            string filename = Path.GetFileNameWithoutExtension(mortgage.BankStatementFile.FileName);
            string extension = Path.GetExtension(mortgage.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            mortgage.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            mortgage.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(mortgage.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(mortgage.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            mortgage.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            mortgage.GoverementIDFile.SaveAs(filename2);

            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                string Username = (string)Session["Username"];
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        mortgage.RegistrationNo = Convert.ToInt32(row["RegistrationID"].ToString());



                    };

                    con.Close();

                }
                using (SqlCommand cmd = new SqlCommand("insertMortgageApplication", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", mortgage.RegistrationNo);
                    cmd.Parameters.AddWithValue("@Occupation", mortgage.Occupation);
                    cmd.Parameters.AddWithValue("@MaritalStatus", mortgage.MaritalStatus);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", mortgage.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@BankStatement", mortgage.BankStatement);
                    cmd.Parameters.AddWithValue("@LoanAmount", mortgage.LoanAmount);
                    cmd.Parameters.AddWithValue("@CompanyName", mortgage.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", mortgage.CompanyAddress);
                    cmd.Parameters.AddWithValue("@HouseAddress", mortgage.HouseAddress);
                    cmd.Parameters.AddWithValue("@GovermentID", mortgage.GovermentID);
                    cmd.Parameters.AddWithValue("@TypeOfMortgage", mortgage.MortgageType);
                    cmd.Parameters.AddWithValue("@BankName", mortgage.BankName);
                    cmd.Parameters.AddWithValue("@BankAccount", mortgage.BankAccount);
                    cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }
        }

        public ActionResult DebtConsolidationLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DebtConsolidationLoanApplication(DebtConsolidationLoan debt)
        {
            string filename = Path.GetFileNameWithoutExtension(debt.BankStatementFile.FileName);
            string extension = Path.GetExtension(debt.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            debt.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            debt.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(debt.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(debt.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            debt.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            debt.GoverementIDFile.SaveAs(filename2);

            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                string Username = (string)Session["Username"];
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        debt.RegistrationNo = Convert.ToInt32(row["RegistrationID"].ToString());



                    };

                    con.Close();

                }
                using (SqlCommand cmd = new SqlCommand("insertDedtConsolidation", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", debt.RegistrationNo);
                    cmd.Parameters.AddWithValue("@Occupation", debt.Occupation);
                    cmd.Parameters.AddWithValue("@MaritalStatus", debt.MaritalStatus);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", debt.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@BankStatement", debt.BankStatement);
                    cmd.Parameters.AddWithValue("@LoanAmount", debt.LoanAmount);
                    cmd.Parameters.AddWithValue("@CompanyName", debt.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", debt.CompanyAddress);
                    cmd.Parameters.AddWithValue("@HouseAddress", debt.HouseAddress);
                    cmd.Parameters.AddWithValue("@GovermentID", debt.GovermentID);
                    cmd.Parameters.AddWithValue("@CollateralName",debt.CollateralName);
                    cmd.Parameters.AddWithValue("@CollateralWorth", debt.CollateralWorth);
                    cmd.Parameters.AddWithValue("@BankName", debt.BankName);
                    cmd.Parameters.AddWithValue("@BankAccount", debt.BankAccount);
                    cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }


         
        }

        public ActionResult BusinessLoanApplication()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["RegistrationID"])))
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        [HttpPost]
        public ActionResult BusinessLoanApplication(BuisnessLoan business)
        {
            string filename = Path.GetFileNameWithoutExtension(business.BankStatementFile.FileName);
            string extension = Path.GetExtension(business.BankStatementFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            business.BankStatement = "~/ApplicationImage/BankStatement/" + filename;
            filename = Path.Combine(Server.MapPath("~/ApplicationImage/BankStatement/"), filename);
            business.BankStatementFile.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(business.GoverementIDFile.FileName);
            string extension2 = Path.GetExtension(business.GoverementIDFile.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension;
            business.GovermentID = "~/ApplicationImage/GovermentID/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/ApplicationImage/GovermentID/"), filename2);
            business.GoverementIDFile.SaveAs(filename2);

            string filename3 = Path.GetFileNameWithoutExtension(business.BuisnessPlanDOC.FileName);
            string extension3 = Path.GetExtension(business.BuisnessPlanDOC.FileName);
            filename3 = filename3 + DateTime.Now.ToString("yymmssfff") + extension;
            business.BuisnessPlan = "~/ApplicationImage/BusinessPlan/" + filename3;
            filename3 = Path.Combine(Server.MapPath("~/ApplicationImage/BusinessPlan/"), filename3);
            business.BuisnessPlanDOC.SaveAs(filename3);

            string filename4 = Path.GetFileNameWithoutExtension(business.businesslicenseDoc.FileName);
            string extension4 = Path.GetExtension(business.businesslicenseDoc.FileName);
            filename4 = filename4 + DateTime.Now.ToString("yymmssfff") + extension;
            business.BuisnessLicencesDocuments = "~/ApplicationImage/BusinessPlan/" + filename4;
            filename4 = Path.Combine(Server.MapPath("~/ApplicationImage/BusinessPlan/"), filename4);
            business.businesslicenseDoc.SaveAs(filename4);


            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                string Username = (string)Session["Username"];
                using (SqlCommand cmd2 = new SqlCommand("Select RegistrationID from CustomerRegistration where Username  = '" + Username + "' ", con))
                {
                    cmd2.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);
                    foreach (DataRow row in dtProducts.Rows)
                    {

                        business.Regno = Convert.ToInt32(row["RegistrationID"].ToString());



                    };

                    con.Close();

                }
                using (SqlCommand cmd = new SqlCommand("insertBusinessLoan", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegistrationID", business.Regno);
                    cmd.Parameters.AddWithValue("@AnnualRevenue", business.AnnualRevenue);
                    cmd.Parameters.AddWithValue("@BankStatement", business.BankStatement);
                    cmd.Parameters.AddWithValue("@BusinessTaxReturn", business.BuisnessTaxReturn);
                    cmd.Parameters.AddWithValue("@LoanAmount", business.loanAmount);
                    cmd.Parameters.AddWithValue("@BuisnessPlan", business.BuisnessPlan);
                    cmd.Parameters.AddWithValue("@CollateralName", business.CollateralName);
                    cmd.Parameters.AddWithValue("@CollateralWorth", business.CollateralWorth);
                    cmd.Parameters.AddWithValue("@GovermentID", business.GovermentID);
                    cmd.Parameters.AddWithValue("@BusinessLicenseDocument", business.BuisnessLicencesDocuments);
                    cmd.Parameters.AddWithValue("@BankName", business.BankName);
                    cmd.Parameters.AddWithValue("@BankAccountNo", business.bankAccount);
                    cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }

        }

        public ActionResult ViewLoanAgeementStructure()
        {
            return View();
        }


    }
}