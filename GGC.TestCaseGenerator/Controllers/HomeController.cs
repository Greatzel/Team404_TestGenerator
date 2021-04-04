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
        /// <summary>
        /// controller's reference to the data model
        /// </summary>
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

        public ActionResult AddMembers()
        {
            return View();
        }

        public ActionResult HowTo()
        {
            return View();
        }
        public ActionResult Results()
        {
            return View();
        }
        public ActionResult InputParameter(InputParameter input)
        {
            return View();
        }
        public ActionResult CoverageGroup()
        {
            return View();
        }

        public ActionResult ExpectedResult(ExpectedResult result)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CoverageGroup(FormCollection fc)
        {
            model.SetNewSpecificationAndName("NewTest");
            model.SetSpecificationText(EntityEnum.Name, "SaveTest");
            model.SetSpecificationText(EntityEnum.Description, "Interface can be saved using any combinations of the parameters");

            model.NewCoverageGroup("CoverageGroupA");
            model.NewCoverageGroup("CoverageGroupB");
            model.NewCoverageGroup("CoverageGroupC");

            model.NewInputParameter("A");
            model.NewInputParameter("B");
            model.NewInputParameter("C");
            model.NewInputParameter("Discriminant");
            model.SetInputParameterText(EntityEnum.Name, "A", "A");
            model.SetInputParameterText(EntityEnum.Value, "A", "A");
            model.SetInputParameterText(EntityEnum.Name, "B", "B");
            model.SetInputParameterText(EntityEnum.Value, "B", "B");
            model.SetInputParameterText(EntityEnum.Name, "C", "C");
            model.SetInputParameterText(EntityEnum.Value, "C", "C");
            model.SetInputParameterText(EntityEnum.Name, "Discriminant", "Discriminant");
            model.SetInputParameterText(EntityEnum.Value, "Discriminant", "discriminant (b^2 - 4ac");

            model.NewEquivalenceClass("A", "0");
            model.NewEquivalenceClass("A", "1");
            model.NewEquivalenceClass("A", "Negative");
            model.NewEquivalenceClass("A", "Postive");
            model.SetEquivalenceClassText(EntityEnum.Name, "A", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Value, "A", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Name, "A", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Value, "A", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Name, "A", "Negative", "Negative");
            model.SetEquivalenceClassText(EntityEnum.Value, "A", "Negative", "any integer in the range (-100, -1)");
            model.SetEquivalenceClassText(EntityEnum.Name, "A", "Positive", "Positive");
            model.SetEquivalenceClassText(EntityEnum.Value, "A", "Positive", "any integer in the range (2, 100)");

            model.NewEquivalenceClass("B", "0");
            model.NewEquivalenceClass("B", "1");
            model.NewEquivalenceClass("B", "Negative");
            model.NewEquivalenceClass("B", "Postive");
            model.SetEquivalenceClassText(EntityEnum.Name, "B", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Value, "B", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Name, "B", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Value, "B", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Name, "B", "Negative", "Negative");
            model.SetEquivalenceClassText(EntityEnum.Value, "B", "Negative", "any integer in the range (-100, -1)");
            model.SetEquivalenceClassText(EntityEnum.Name, "B", "Positive", "Positive");
            model.SetEquivalenceClassText(EntityEnum.Value, "B", "Positive", "any integer in the range (2, 100)");

            model.NewEquivalenceClass("C", "0");
            model.NewEquivalenceClass("C", "1");
            model.NewEquivalenceClass("C", "Negative");
            model.NewEquivalenceClass("C", "Postive");
            model.SetEquivalenceClassText(EntityEnum.Name, "C", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Value, "C", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Name, "C", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Value, "C", "1", "1");
            model.SetEquivalenceClassText(EntityEnum.Name, "C", "Negative", "Negative");
            model.SetEquivalenceClassText(EntityEnum.Value, "C", "Negative", "any integer in the range (-100, -1)");
            model.SetEquivalenceClassText(EntityEnum.Name, "C", "Positive", "Positive");
            model.SetEquivalenceClassText(EntityEnum.Value, "C", "Positive", "any integer in the range (2, 100)");

            model.NewEquivalenceClass("Discriminant", "0");
            model.NewEquivalenceClass("Discriminant", "LessThanZero");
            model.NewEquivalenceClass("Discriminant", "GreaterThanZero");
            model.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "0", "0");
            model.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "LessThanZero", "1");
            model.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "LessThanZero", "N less than 0");
            model.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "GreaterThanZero", "GreaterThanZero");
            model.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "GreaterThanZero", "N greater than 0");

            model.NewExpectedResult("FirstQuadraticRoot");
            model.NewExpectedResult("SecondQuadraticRoot");
            model.NewExpectedResult("OneQuadraticRoot");
            model.NewExpectedResult("FirstImaginaryRoot");
            model.NewExpectedResult("SecondImaginaryRoot");
            model.NewExpectedResult("UndefinedRoots");
            model.SetExpectedResultText(EntityEnum.Name, "FirstQuadraticRoot", "FirstQuadraticRoot");
            model.SetExpectedResultText(EntityEnum.Value, "FirstQuadraticRoot", "first root is (-b + SQRT(b^2 - 4ac))/2a");
            model.SetExpectedResultText(EntityEnum.Condition, "FirstQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            model.SetExpectedResultText(EntityEnum.Name, "SecondQuadraticRoot", "SecondQuadraticRoot");
            model.SetExpectedResultText(EntityEnum.Value, "SecondQuadraticRoot", "second root is (-b - SQRT(b^2 - 4ac))/2a");
            model.SetExpectedResultText(EntityEnum.Condition, "SecondQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            model.SetExpectedResultText(EntityEnum.Name, "OneQuadraticRoot", "OneQuadraticRoot");
            model.SetExpectedResultText(EntityEnum.Value, "OneQuadraticRoot", "only root is -b/2a");
            model.SetExpectedResultText(EntityEnum.Condition, "OneQuadraticRoot", "A != 0 and Discriminant = 0");

            model.SetExpectedResultText(EntityEnum.Name, "FirstImaginaryRoot", "FirstImaginaryRoot");
            model.SetExpectedResultText(EntityEnum.Value, "FirstImaginaryRoot", "first imaginary root is (-b + [i]SQRT(4ac - b^2))/2a");
            model.SetExpectedResultText(EntityEnum.Condition, "FirstImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            model.SetExpectedResultText(EntityEnum.Name, "SecondImaginaryRoot", "SecondImaginaryRoot");
            model.SetExpectedResultText(EntityEnum.Value, "SecondImaginaryRoot", "second imaginary root is (-b - [i]SQRT(4ac - b^2))/2a");
            model.SetExpectedResultText(EntityEnum.Condition, "SecondImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            model.SetExpectedResultText(EntityEnum.Name, "UndefinedRoots", "UndefinedRoots");
            model.SetExpectedResultText(EntityEnum.Value, "UndefinedRoots", "roots are undefined");
            model.SetExpectedResultText(EntityEnum.Condition, "UndefinedRoots", "A = 0");
            model.WriteSpecification("Test1234456");
            

            return View();
        }

        [HttpPost]
        public ActionResult AddSpecification()
        {
            model.SetNewSpecificationAndName(Request.Form["name"]);
            model.SetSpecificationText(EntityEnum.Given, Request.Form["given"]);
            model.SetSpecificationText(EntityEnum.Description, Request.Form["Description"]);
            return View();
        }

        [HttpPost]
        public ActionResult InputParameter()
        {
            model.NewInputParameter(Request.Form["IPara1"]);
            model.SetInputParameterText(EntityEnum.Value, Request.Form["IPara1"], Request.Form["IPara2"]);
            return View();
        }

        public ActionResult EquivalenceClass()
        {
            model.NewEquivalenceClass("inputParameterName", "equivalenceClassName");
            model.SetEquivalenceClassText(EntityEnum.Given, "inputParameterName", "equivalenceClassName", "Given");
            model.SetEquivalenceClassText(EntityEnum.Value, "inputParameterName", "equivalenceClassName", "Value");
            model.SetEquivalenceClassText(EntityEnum.Condition, "inputParameterName", "equivalenceClassName", "Condition");
            return View();
        }
        [HttpPost]
        public ActionResult ExpectedResult()
        {
            model.NewExpectedResult(Request.Form["name"]);
            model.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["given"]);
            model.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["value"]);
            model.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["condition"]);
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
    }
}