using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using github.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace github.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;
        public HomeController( IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            //string connString = this.Configuration.GetConnectionString("DefaultConnection");

            //string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //using (MySqlConnection con = new MySqlConnection(connString))
            //{
            //    string query = "SELECT contact_name FROM contacts where id=6";
            //    using (MySqlCommand cmd = new MySqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        using (MySqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                ViewBag.Message = sdr["contact_name"].ToString();
            //            }
            //        }
            //        con.Close();
            //    }
            //}
            //return View();

            List<ModelClass> name = new List<ModelClass>();
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                string query = "SELECT id,contact_name FROM contacts";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            name.Add(new ModelClass
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                contact_name = sdr["contact_name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return View(name);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
