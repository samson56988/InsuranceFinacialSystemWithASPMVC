using LoanFinancialSoftware.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanFinancialSoftware.Models.LoanServices;
using System.Web.Security;
using LoanFinancialSoftware.Models.FinancialAnalysis;
using LoanFinancialSoftware.Models.AgreementForm;

namespace LoanFinancialSoftware.Controllers.LoanOfficer
{
    public class LoanOfficerController : Controller
    {
        // GET: LoanOfficer
        public ActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Username"])))
            {
                return RedirectToAction("Login", "StaffAuthentication");
            }
            return View();
        }

        public ActionResult PersonalLoanApplicationRecord()
        {
            List<PersonalLoan> personal = new List<PersonalLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',p.Occupation, p.MonthlyIncome,p.LoanAmount,p.ApplicationID  from PersonalLoan p  inner join CustomerRegistration c on p.RegistrationID = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        personal.Add(
                            new PersonalLoan
                            {
                                ApplicationID = Convert.ToInt32(row["ApplicationID"]),
                               Fullname  = row["Party Name"].ToString(),
                               Occupation = row["Occupation"].ToString(),
                               MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]),
                               LoanAmount = Convert.ToDecimal(row["LoanAmount"])
                               
                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(personal);
        }

        public ActionResult PayDayLoanApplicationRecord()
        {
            List<PayDayLoan> payday = new List<PayDayLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',p.Occupation, p.MonthlyIncome,p.LoanAmount from PayDayLoan p  inner join CustomerRegistration c on p.RegNo = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        payday.Add(
                            new PayDayLoan
                            {
                                Fullname = row["Party Name"].ToString(),
                                Occupation = row["Occupation"].ToString(),
                                MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]),
                                LoanAmount = Convert.ToDecimal(row["LoanAmount"])

                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(payday);
        }

        public ActionResult AutoLoan()
        {
            List<AutoLoan> auto = new List<AutoLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',a.Occupation, a.MonthlyIncome,a.LoanAmount from AutoLoan a  inner join CustomerRegistration c on a.RegNo = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        auto.Add(
                            new AutoLoan
                            {
                                Fullname = row["Party Name"].ToString(),
                                Occupation = row["Occupation"].ToString(),
                                MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]),
                                LoanAmount = Convert.ToDecimal(row["LoanAmount"])

                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(auto);

        }

        public ActionResult MortgageLoanApplicationRecord()
        {
            List<MortgageLoan> mortgage = new List<MortgageLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',m.Occupation, m.MonthlyIncome,m.LoanAmount from MortgageLoan m  inner join CustomerRegistration c on m.RegistrationID = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        mortgage.Add(
                            new MortgageLoan
                            {
                                Fullname = row["Party Name"].ToString(),
                                Occupation = row["Occupation"].ToString(),
                                MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]),
                                LoanAmount = Convert.ToDecimal(row["LoanAmount"])

                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(mortgage);



            
        }

        public ActionResult ConsolidationLoanApplicationRecord()
        {
            List<DebtConsolidationLoan> debt = new List<DebtConsolidationLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',d.Occupation, d.MonthlyIncome,d.LoanAmount from DebtConsolidationLoan d  inner join CustomerRegistration c on d.RegistrationID = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        debt.Add(
                            new DebtConsolidationLoan
                            {
                                Fullname = row["Party Name"].ToString(),
                                Occupation = row["Occupation"].ToString(),
                                MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]),
                                LoanAmount = Convert.ToDecimal(row["LoanAmount"])

                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(debt);
        }

        public ActionResult BusinessLoanApplicationRecord()
        {
            List<BuisnessLoan> business = new List<BuisnessLoan>();
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',b.AnnualRevenue, b.BuisnessTaxReturn,b.LoanAmount from BuisnessLoan b  inner join CustomerRegistration c on b.RegistrationID = c.RegistrationID", con))
                {
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach (DataRow row in dtProducts.Rows)
                    {
                        business.Add(
                            new BuisnessLoan
                            {
                                Fullname = row["Party Name"].ToString(),
                                AnnualRevenue = Convert.ToDecimal(row["AnnualRevenue"]),
                                loanAmount = Convert.ToDecimal(row["LoanAmount"]),
                                BuisnessTaxReturn = Convert.ToDecimal(row["BuisnessTaxReturn"])

                            }



                            );
                    }
                    con.Close();
                }
            }

            return View(business);
        }
        
        public ActionResult ReviewPersonalLoan(int id)
        {
            PersonalLoan personal = new PersonalLoan();

            DataTable dtpersonal = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(StoreConnections.GetConnection()))
            {
                sqlcon.Open();
                string query = "select c.Firstname + ' '+c.Secondname+' '+c.Lastname as 'Party Name',p.Occupation, p.MonthlyIncome,p.LoanAmount,p.MaritalStatus,p.CompanyName,p.CompanyAddress,p.HouseAddress,p.BankName,p.BankAccountNo,p.DateApplied,p.ApplicationID  from PersonalLoan p  inner join CustomerRegistration c on p.RegistrationID = c.RegistrationID where p.ApplicationID = @ApplicationID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ApplicationID", id);
                sqlDa.Fill(dtpersonal);



            }
            if (dtpersonal.Rows.Count == 1)
            {
                personal.Fullname = dtpersonal.Rows[0][0].ToString();
                personal.Occupation = dtpersonal.Rows[0][1].ToString();
                personal.MonthlyIncome = Convert.ToDecimal(dtpersonal.Rows[0][2].ToString());
                personal.LoanAmount = Convert.ToDecimal(dtpersonal.Rows[0][3].ToString());
                personal.MaritalStatus = dtpersonal.Rows[0][4].ToString();
                personal.CompanyName = dtpersonal.Rows[0][5].ToString();
                personal.CompanyAddress = dtpersonal.Rows[0][6].ToString();
                personal.HouseAddress = dtpersonal.Rows[0][7].ToString();
                personal.BankName = dtpersonal.Rows[0][8].ToString();
                personal.BankAccount = Convert.ToInt32(dtpersonal.Rows[0][9].ToString());
                personal.ApplicationDate = Convert.ToDateTime(dtpersonal.Rows[0][10].ToString());
                personal.ApplicationID = Convert.ToInt32(dtpersonal.Rows[0][11].ToString());

                FormsAuthentication.SetAuthCookie(Convert.ToInt32(personal.ApplicationID).ToString(), true);
                Session["ApplicationID"] = personal.ApplicationID.ToString();

                return View(personal);


            }
            else

                return RedirectToAction("PersonalLoanApplicationRecord");


            
        }

        public FileContentResult DownloadBankStatement(PersonalLoan personal)
        {
            SqlDataReader dr;
            string filename = "";
            byte[] Filecontent = null;
            string fileType = "";
            string ApplicationID = (string)Session["ApplicationID"];
            using (SqlConnection sqlcon = new SqlConnection(StoreConnections.GetConnection()))
            {
                
                string query = "select BankStatement from PersonalLoan where ApplicationID = '"+ApplicationID+"'";
                var cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@ApplicationID", personal.ApplicationID);
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    Filecontent = (byte[])dr["BankStatement"];
                    filename = dr["BankStatement"].ToString();                 
                    fileType = dr["BankStatement"].ToString();



                }
                


            }

            return File(Filecontent,fileType,filename);



        }

        public ActionResult Approveloan(PersonalLoan Loan)
        {
            string ApplicationID = (string)Session["ApplicationID"];
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
               
                using (SqlCommand cmd = new SqlCommand("Update PersonalLoan set Status = 'Approved' where ApplicationID  = '" +ApplicationID + "' ", con))
                {
                  
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                     cmd.ExecuteNonQuery();
                    return RedirectToAction("PersonalLoanApplicationRecord");



                }
            }
        }

        public ActionResult DeclineLoan(PersonalLoan loan)
        {
            string ApplicationID = (string)Session["ApplicationID"];
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("Update PersonalLoan set Status = 'Declined' where ApplicationID  = '" + ApplicationID + "' ", con))
                {

                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    cmd.ExecuteNonQuery();
                    return RedirectToAction("PersonalLoanApplicationRecord");



                }
            }
        }

        public ActionResult TransactionAnalysis()
        {

            string ApplicationID = (string)Session["ApplicationID"];
            PersonalLoanFinancialAnalysis personal = new PersonalLoanFinancialAnalysis();

            DataTable dtpersonal = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(StoreConnections.GetConnection()))
            {
                sqlcon.Open();
                string query = "select  LoanAmount,ApplicationID,c.RegistrationID from PersonalLoan p inner join CustomerRegistration c on p.RegistrationID = c.RegistrationID where ApplicationID = '" + ApplicationID+"' ";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                sqlDa.Fill(dtpersonal);
            }
            if (dtpersonal.Rows.Count == 1)
            {
                personal.PrincipalLoan = Convert.ToDecimal(dtpersonal.Rows[0][0].ToString());
                personal.ApplicationID = Convert.ToInt32(dtpersonal.Rows[0][1].ToString());
                personal.Regno = Convert.ToInt32(dtpersonal.Rows[0][2].ToString());
                FormsAuthentication.SetAuthCookie(Convert.ToInt32(personal.ApplicationID).ToString(), true);
                Session["ApplicationID"] = personal.ApplicationID.ToString();
                return View(personal);


            }
            else

                return View();
        }

        [HttpPost]
        public ActionResult TransactionAnalysis(PersonalLoanFinancialAnalysis personal)
        {
            
            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                
                using (SqlCommand cmd = new SqlCommand("InsertPersonalFinanceAnalysis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApplicationID", personal.ApplicationID);
                    cmd.Parameters.AddWithValue("@principal", personal.PrincipalLoan);
                    cmd.Parameters.AddWithValue("@LoanTerm", personal.LoanTerm);
                    cmd.Parameters.AddWithValue("@Intrestrate", personal.IntrestRate);
                    cmd.Parameters.AddWithValue("@RegNo", personal.Regno);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                return View();
            }


        }
        

        public ActionResult SendloanTermandcondition(PersonalLoanAgreement personal)
        {
            string ApplicationID = (string)Session["ApplicationID"];
            

            DataTable dtpersonal = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(StoreConnections.GetConnection()))
            {
                sqlcon.Open();
                string query = "select  * from PersonalLoan p inner join CustomerRegistration c on p.RegistrationID = c.RegistrationID inner join PersonalFinacialAnalysis pf on p.ApplicationID = pf.ApplicationID where p.ApplicationID = '" + ApplicationID + "' ";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.Fill(dtpersonal);
            }
            if (dtpersonal.Rows.Count == 1)
            {
                personal.ApplicationID = Convert.ToInt32(dtpersonal.Rows[0][0].ToString());
                personal.PrincipalLoan = Convert.ToDecimal(dtpersonal.Rows[0][28].ToString());
                personal.IntrestRate = Convert.ToInt32(dtpersonal.Rows[0][30].ToString());
                personal.LoanTerm = Convert.ToInt32(dtpersonal.Rows[0][29].ToString());
                personal.TotalIntrest = Convert.ToDecimal(dtpersonal.Rows[0][32].ToString());
                personal.TotalDailyIntrest = Convert.ToDecimal(dtpersonal.Rows[0][31].ToString());
                personal.RepaymentAmount = Convert.ToDecimal(dtpersonal.Rows[0][34].ToString());
                personal.TotalRepaymentAmount = Convert.ToDecimal(dtpersonal.Rows[0][35].ToString());
                personal.EmailID = dtpersonal.Rows[0][25].ToString();
                personal.Regno = Convert.ToInt32(dtpersonal.Rows[0][1].ToString());
                personal.HouseAddress = dtpersonal.Rows[0][9].ToString();
                FormsAuthentication.SetAuthCookie(Convert.ToInt32(personal.ApplicationID).ToString(), true);
                Session["ApplicationID"] = personal.ApplicationID.ToString();
                return View(personal);


            }
            else

                return View();

            
        }
    }
}