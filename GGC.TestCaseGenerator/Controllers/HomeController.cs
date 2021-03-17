using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGC.TestCaseGenerator.Models;

namespace GGC.TestCaseGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult CoverageGroup()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSpecification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecification(InputParameter testSpecification)
        {
            ViewBag.Message = "Your contact page.";
            //Save Specification
            InputParameter input = new InputParameter(testSpecification.Name, testSpecification.Text);

            //Redirect

            return Redirect("/");
        }
    }
}