using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegistry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        //public string Index()
        {
            return View();
            //return "Hello from Home";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Employee Registry Tracking System";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information:";

            return View();
        }
    }
}