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

        private readonly ModelInterfaceController model;

        public HomeController()
        {
            model = new ModelInterfaceController();
        }

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

        public ActionResult AddSpecification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpectedResult(FormCollection re)
        {
            var name = Request.Form["ExpectedResultsName"];
            var text = Request.Form["ExpectedResultsText"];
            var conditions = Request.Form["ExpectedResultsCondition"];
            var test = "Breakpoint test";
            return View();
        }
        public ActionResult ExpectedResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecification(FormCollection cc)
        {
            //========================================================
            /*
             */
            //========================================================
            var addSpecificationName = Request.Form["specificationName"];
            var addSpecificationText = Request.Form["specificationTextName"];
            var test = "Breakpoint test";
            return View();
        }

        [HttpPost]
        public ActionResult CoverageGroup(FormCollection fc)
        {

            //<===============================Greatzel1===============================>
            /*
             * groupNameString - contains the entered NAME of the GROUP 
             *  eg: "Group A"
             * groupMembersString - contains the entered MEMBERS selected in one STRING
             *  eg: "Member1","Member2","Member3"           
             */

            //var groupNameString = Request.Form["groupname"];
            //var groupMembersString = Request.Form["CoverageGroupArrayName"];


            //<========================================================================>

            var groupNameString = Request.Form["groupname"];
            var groupMembersString = Request.Form["CoverageGroupArrayName"];

            model.CreateCoverageGroup(Request.Form["groupname"], 
                Request.Form["CoverageGroupArrayName"]);

            var test = "break point test";
            return View();
        }

        public ActionResult HowTo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputParameter(FormCollection gc)
        {

            //<===============================Greatzel1===============================>
            /*
             * inputParametersNameString - contains the entered LIST of NAMES of the INPUT PARAMETERS 
             *  eg: "Input A", "Input B", "Input C"
             * inputParametersTextString - contains the entered MEMBERS selected in one STRING
             *  eg: "Member1","Member2","Member3"     
             * EquivalenceNamesString - contains the entered LIST of NAMES of the INPUT PARAMETERS 
             *  eg: "Input A", "Input B", "Input C"
             * EquivalenceTextString - contains the entered MEMBERS selected in one STRING
             *  eg: "Member1","Member2","Member3"
             */

            //var groupNameString = Request.Form["groupname"];
            //var groupMembersString = Request.Form["CoverageGroupArrayName"];

            var inputParameterNameString = Request.Form["InputParameterNames"];
            var inputParameterTextString = Request.Form["InputParameterText"];
            var EquivalenceNamesString = Request.Form["EquivalenceClassNames"];
            var EquivalenceTextString = Request.Form["EquivalenceClassText"];
            var test = "break point test";

            //<========================================================================>         
            return View();
        }
        public ActionResult InputParameter()
        {
            return View();
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