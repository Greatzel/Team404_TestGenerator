using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGC.TestCaseGenerator.Models;

namespace GGC.TestCaseGenerator.Controllers
{
    public class HomeController : Controller
    {

        ModelInterfaceController tempNameInterface = new ModelInterfaceController();
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

        public ActionResult Resources()
        {
            return View();
        }

        public ActionResult AddMembers()
        {
            return View();
        }
        public ActionResult Result()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CoverageGroup(FormCollection fc)
        {
            tempNameInterface.CreateCoverageGroup(Request.Form["groupname"], 
                Request.Form["CoverageGroupArrayName"]);         
            return View();
        }

        public ActionResult AddSpecification()
        {         
            return View();
        }

        public ActionResult HowTo()
        {
            return View();
        }
        public ActionResult InputParameter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputParameter(InputParameter testSpecification)
        {
            ViewBag.Message = "Your contact page.";
            //Save Specification
            InputParameter input = new InputParameter(testSpecification.Name, testSpecification.Text);

            //Redirect

            return Redirect("/");
        }

        //Get data test
        [HttpPost]
        public ActionResult Test(string text)
        {
            ViewBag.DisplayText = text;
            return Redirect(text);

            //return View();
        }

        [HttpPost]
        public ActionResult AddMembers(FormCollection members)
        {
           
            return View();
        }
    }
}