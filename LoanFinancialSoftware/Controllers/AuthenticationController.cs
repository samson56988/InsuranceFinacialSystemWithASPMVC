using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using LoanFinancialSoftware.Models;
using System.Configuration;
using LoanFinancialSoftware.Config;
using System.Web.Security;

namespace LoanFinancialSoftware.Controllers
{
    public class AuthenticationController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Login lg)
        {
            int RegistrationID;
            string usernam = "";
            bool found = false;
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from CustomerRegistration where Username = '" + lg.Username + "' and Password = '" + lg.Password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                found = true;
                RegistrationID =Convert.ToInt32(dr["RegistrationID"].ToString());
                usernam = dr["Username"].ToString();
                FormsAuthentication.SetAuthCookie(lg.Username, true);
                Session["Username"] = lg.Username.ToString();
                FormsAuthentication.SetAuthCookie(Convert.ToInt32(lg.RegNo).ToString(), true);
                Session["RegistrationID"] = lg.RegNo.ToString();
            }
            else
            {
                found = false;
            }
            dr.Close();
            con.Close();
            if (found == true)
            {             
                    FormsAuthentication.SetAuthCookie(lg.Username, true);
                    Session["Username"] = lg.Username.ToString();
                    Session["RegistrationID"] = lg.RegNo.ToString();
                return RedirectToAction("Dashboard", "Customer");
            }
            else
            {
                ViewData["message"] = "Username & password are wrong!";
            }
            con.Close();
            return View();

        }


        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Register(CustomerRegistration customer)
        {

            using (SqlConnection con = new SqlConnection(StoreConnections.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("insertCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firstname", customer.Firstname);
                    cmd.Parameters.AddWithValue("@Middlename", customer.Secondname);
                    cmd.Parameters.AddWithValue("@Lastname", customer.Lastname);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@Username", customer.Username);
                    cmd.Parameters.AddWithValue("@Password", customer.Password);
                    cmd.Parameters.AddWithValue("@EmailID", customer.Email);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();

                }
                con.Close();


                return RedirectToAction("Login");

            }



        }


        void connectionString()
        {
            con.ConnectionString = "Data Source = DESKTOP-J3DHBNP\\;Initial Catalog=LoanManagementSystem;Integrated Security=True";

        }


    }
}