using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanFinancialSoftware.Models.CustomerService;
using System.Web.Security;

namespace LoanFinancialSoftware.Controllers.Client
{
    public class StaffAuthenticationController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: StaffAuthentication
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            
            string designation = "";
            string usernam = "";
            bool found = false;
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from StaffTble where Username = '" + lg.username + "' and Password = '" + lg.password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                found = true;
                designation = dr["Designation"].ToString();
                usernam = dr["Username"].ToString();
                FormsAuthentication.SetAuthCookie(lg.username, true);
                Session["Username"] = lg.username.ToString();
                
            }
            else
            {
                found = false;
            }
            dr.Close();
            con.Close();
            if (found == true)
            {
                if (designation == "Loan Officer")
                {
                    FormsAuthentication.SetAuthCookie(lg.username, true);
                    Session["Username"] = lg.username.ToString();
                    return RedirectToAction("Dashboard", "LoanOfficer");

                }
                else if(designation == "HR")
                {
                    FormsAuthentication.SetAuthCookie(lg.username, true);
                    Session["Username"] = lg.username.ToString();
                    return RedirectToAction("/Views/AdminFunctions/Admin/Index.cshtml");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(lg.username, true);
                    Session["Username"] = lg.username.ToString();
                    return RedirectToAction("/Views/AdminFunctions/Admin/Index.cshtml");
                }
               
            }
            else
            {
                ViewData["message"] = "Username & password are wrong!";
            }
            con.Close();
            return View();
           
        }


        void connectionString()
        {
            con.ConnectionString = "Data Source = DESKTOP-J3DHBNP\\;Initial Catalog=LoanManagementSystem;Integrated Security=True";

        }

    }
}