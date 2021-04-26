using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGC.TestCaseGenerator.Models;

namespace GGC.TestCaseGenerator.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// controller's reference to the data testSpecification
        /// </summary>
        private readonly ModelInterfaceController testSpecification;

        public HomeController()
        {
            testSpecification = new ModelInterfaceController();
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
        public ActionResult AddSpecification()
        {
            return View();
        }
        public ActionResult InputParameter()
        {
            return View();
        }
        public ActionResult CoverageGroup()
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
        
        public ActionResult ExpectedResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecification(FormCollection fc)
        {
            /* testSpecification.SetNewSpecificationAndName("SaveTest");
            testSpecification.SetSpecificationText(EntityEnum.Name, "SaveTest");
            testSpecification.SetSpecificationText(EntityEnum.Description, "Interface can be saved using any combinations of the parameters"); */
            return View();
        }

        [HttpPost]
        public ActionResult CoverageGroup(FormCollection fc, ModelInterfaceController modelInterface)
        {
            /* ModelInterfaceController testSpecification = modelInterface;
            testSpecification.NewCoverageGroup("CoverageGroupA");
            testSpecification.NewCoverageGroup("CoverageGroupB");
            testSpecification.NewCoverageGroup("CoverageGroupC"); */
            return View();
        }

        [HttpPost]
        public ActionResult InputParameter(FormCollection fc, ModelInterfaceController modelInterface)
        {
            /*ModelInterfaceController testSpecification = modelInterface;
            testSpecification.NewInputParameter("A");
            testSpecification.NewInputParameter("B");
            testSpecification.NewInputParameter("C");
            testSpecification.NewInputParameter("Discriminant");
            testSpecification.SetInputParameterText(EntityEnum.Name, "A", "A");
            testSpecification.SetInputParameterText(EntityEnum.Value, "A", "A");
            testSpecification.SetInputParameterText(EntityEnum.Name, "B", "B");
            testSpecification.SetInputParameterText(EntityEnum.Value, "B", "B");
            testSpecification.SetInputParameterText(EntityEnum.Name, "C", "C");
            testSpecification.SetInputParameterText(EntityEnum.Value, "C", "C");
            testSpecification.SetInputParameterText(EntityEnum.Name, "Discriminant", "Discriminant");
            testSpecification.SetInputParameterText(EntityEnum.Value, "Discriminant", "discriminant (b^2 - 4ac"); */
            return View();
        }

        [HttpPost]
        public ActionResult EquivalenceClass(FormCollection fc, ModelInterfaceController modelInterface)
        {
            /*ModelInterfaceController testSpecification = modelInterface;
            testSpecification.NewEquivalenceClass("A", "0");
            testSpecification.NewEquivalenceClass("A", "1");
            testSpecification.NewEquivalenceClass("A", "Negative");
            testSpecification.NewEquivalenceClass("A", "Postive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("B", "0");
            testSpecification.NewEquivalenceClass("B", "1");
            testSpecification.NewEquivalenceClass("B", "Negative");
            testSpecification.NewEquivalenceClass("B", "Postive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("C", "0");
            testSpecification.NewEquivalenceClass("C", "1");
            testSpecification.NewEquivalenceClass("C", "Negative");
            testSpecification.NewEquivalenceClass("C", "Postive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("Discriminant", "0");
            testSpecification.NewEquivalenceClass("Discriminant", "LessThanZero");
            testSpecification.NewEquivalenceClass("Discriminant", "GreaterThanZero");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "LessThanZero", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "LessThanZero", "N less than 0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "GreaterThanZero", "GreaterThanZero");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "GreaterThanZero", "N greater than 0"); */
            return View();
        }

        [HttpPost]
        public ActionResult ExpectedResult(FormCollection fc, ModelInterfaceController modelInterface)
        {
            /*ModelInterfaceController testSpecification = modelInterface;
            testSpecification.NewExpectedResult("FirstQuadraticRoot");
            testSpecification.NewExpectedResult("SecondQuadraticRoot");
            testSpecification.NewExpectedResult("OneQuadraticRoot");
            testSpecification.NewExpectedResult("FirstImaginaryRoot");
            testSpecification.NewExpectedResult("SecondImaginaryRoot");
            testSpecification.NewExpectedResult("UndefinedRoots");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "FirstQuadraticRoot", "FirstQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "FirstQuadraticRoot", "first root is (-b + SQRT(b^2 - 4ac))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "FirstQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Name, "SecondQuadraticRoot", "SecondQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "SecondQuadraticRoot", "second root is (-b - SQRT(b^2 - 4ac))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "SecondQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Name, "OneQuadraticRoot", "OneQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "OneQuadraticRoot", "only root is -b/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "OneQuadraticRoot", "A != 0 and Discriminant = 0");


            testSpecification.SetExpectedResultText(EntityEnum.Name, "FirstImaginaryRoot", "FirstImaginaryRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "FirstImaginaryRoot", "first imaginary root is (-b + [i]SQRT(4ac - b^2))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "FirstImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Name, "SecondImaginaryRoot", "SecondImaginaryRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "SecondImaginaryRoot", "second imaginary root is (-b - [i]SQRT(4ac - b^2))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "SecondImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Name, "UndefinedRoots", "UndefinedRoots");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "UndefinedRoots", "roots are undefined");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "UndefinedRoots", "A = 0"); */
            return View();
        }

        [HttpPost]
        public ActionResult Results(FormCollection fc)
        {
            string testspecifications = Request.Form["specNameRes"];
            testSpecification.SetNewSpecificationAndName(testspecifications);
            testSpecification.SetSpecificationText(EntityEnum.Name, testspecifications);
            testSpecification.SetSpecificationText(EntityEnum.Description, Request.Form["specTextRes"]);

            testSpecification.NewCoverageGroup(Request.Form["groupNameRes"]);
            testSpecification.NewCoverageGroup("CoverageGroupB");
            testSpecification.NewCoverageGroup("CoverageGroupC");

            testSpecification.NewInputParameter("A");
            testSpecification.NewInputParameter("B");
            testSpecification.NewInputParameter("C");
            testSpecification.NewInputParameter("Discriminant");

            testSpecification.SetInputParameterText(EntityEnum.Name, "A", "A");
            testSpecification.SetInputParameterText(EntityEnum.Value, "A", "A");
            testSpecification.SetInputParameterText(EntityEnum.Name, "B", "B");
            testSpecification.SetInputParameterText(EntityEnum.Value, "B", "B");
            testSpecification.SetInputParameterText(EntityEnum.Name, "C", "C");
            testSpecification.SetInputParameterText(EntityEnum.Value, "C", "C");
            testSpecification.SetInputParameterText(EntityEnum.Name, "Discriminant", "Discriminant");
            testSpecification.SetInputParameterText(EntityEnum.Value, "Discriminant", "Discriminant (b^2 - 4ac");

            testSpecification.NewEquivalenceClass("A", "0");
            testSpecification.NewEquivalenceClass("A", "1");
            testSpecification.NewEquivalenceClass("A", "Negative");
            testSpecification.NewEquivalenceClass("A", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "A", "0", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "A", "1", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "A", "Negative", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "A", "Positive", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "A", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "A", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("B", "0");
            testSpecification.NewEquivalenceClass("B", "1");
            testSpecification.NewEquivalenceClass("B", "Negative");
            testSpecification.NewEquivalenceClass("B", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "B", "0", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "B", "1", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "B", "Negative", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "B", "Positive", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "B", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "B", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("C", "0");
            testSpecification.NewEquivalenceClass("C", "1");
            testSpecification.NewEquivalenceClass("C", "Negative");
            testSpecification.NewEquivalenceClass("C", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "C", "0", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "C", "1", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "1", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "C", "Negative", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "Negative", "Negative");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "Negative", "any integer in the range (-100, -1)");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "C", "Positive", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "C", "Positive", "Positive");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "C", "Positive", "any integer in the range (2, 100)");

            testSpecification.NewEquivalenceClass("Discriminant", "0");
            testSpecification.NewEquivalenceClass("Discriminant", "LessThanZero");
            testSpecification.NewEquivalenceClass("Discriminant", "GreaterThanZero");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "Discriminant", "0", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "0", "0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "Discriminant", "LessThanZero", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "LessThanZero", "1");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "LessThanZero", "N less than 0");
            testSpecification.SetEquivalenceClassText(EntityEnum.Given, "Discriminant", "GreaterThanZero", "Given Text");
            testSpecification.SetEquivalenceClassText(EntityEnum.Name, "Discriminant", "GreaterThanZero", "GreaterThanZero");
            testSpecification.SetEquivalenceClassText(EntityEnum.Value, "Discriminant", "GreaterThanZero", "N greater than 0");

            testSpecification.NewExpectedResult("FirstQuadraticRoot");
            testSpecification.NewExpectedResult("SecondQuadraticRoot");
            testSpecification.NewExpectedResult("OneQuadraticRoot");
            testSpecification.NewExpectedResult("FirstImaginaryRoot");
            testSpecification.NewExpectedResult("SecondImaginaryRoot");
            testSpecification.NewExpectedResult("UndefinedRoots");
            testSpecification.SetExpectedResultText(EntityEnum.Given, "FirstQuadraticRoot", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "FirstQuadraticRoot", "FirstQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "FirstQuadraticRoot", "first root is (-b + SQRT(b^2 - 4ac))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "FirstQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Given, "SecondQuadraticRoot", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "SecondQuadraticRoot", "SecondQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "SecondQuadraticRoot", "second root is (-b - SQRT(b^2 - 4ac))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "SecondQuadraticRoot", "A != 0 and Discriminant = GreaterThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Given, "OneQuadraticRoot", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "OneQuadraticRoot", "OneQuadraticRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "OneQuadraticRoot", "only root is -b/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "OneQuadraticRoot", "A != 0 and Discriminant = 0");

            testSpecification.SetExpectedResultText(EntityEnum.Given, "FirstImaginaryRoot", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "FirstImaginaryRoot", "FirstImaginaryRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "FirstImaginaryRoot", "first imaginary root is (-b + [i]SQRT(4ac - b^2))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "FirstImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Given, "SecondImaginaryRoot", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "SecondImaginaryRoot", "SecondImaginaryRoot");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "SecondImaginaryRoot", "second imaginary root is (-b - [i]SQRT(4ac - b^2))/2a");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "SecondImaginaryRoot", "A != 0 and Discriminant = LessThanZero");

            testSpecification.SetExpectedResultText(EntityEnum.Given, "UndefinedRoots", "Given Text");
            testSpecification.SetExpectedResultText(EntityEnum.Name, "UndefinedRoots", "UndefinedRoots");
            testSpecification.SetExpectedResultText(EntityEnum.Value, "UndefinedRoots", "roots are undefined");
            testSpecification.SetExpectedResultText(EntityEnum.Condition, "UndefinedRoots", "A = 0");
            /*string parameterList = Request.Form["inputNameSheshStored"];

            List<string> inputParameterList = parameterList.Split(',').ToList();
            List<string> equivalenceClassList = Request.Form["expectedResName"].Split(',').ToList();
            List<string> equivalenceClassListText = Request.Form["expectedResName"].Split(',').ToList();
            List<string> equivalenceClassListCondition = Request.Form["expectedResName"].Split(',').ToList();
            foreach (string ip in inputParameterList)
            {
                testSpecification.NewInputParameter(ip);
                testSpecification.SetInputParameterText(EntityEnum.Name, ip, ip);
                testSpecification.SetInputParameterText(EntityEnum.Value, ip, ip);
                foreach (string ec in equivalenceClassList)
                {
                    testSpecification.NewEquivalenceClass(ip, ec);
                }
                foreach (string ec in equivalenceClassListText)
                {
                    testSpecification.NewEquivalenceClass(ip, ec);
                }
                foreach (string ec in equivalenceClassListCondition)
                {
                    testSpecification.NewEquivalenceClass(ip, ec);
                }

            }
            testSpecification.NewCoverageGroup(Request.Form["groupName"]);
            List<string> expectedResultList = Request.Form["expectedResName"].Split(',').ToList();
            List<string> expectedResultListText = Request.Form["expectedResText"].Split(',').ToList();
            List<string> expectedResultListCon = Request.Form["expectedResResCon"].Split(',').ToList();
            foreach (string er in expectedResultList)
            {
                testSpecification.NewExpectedResult(er);
                testSpecification.SetExpectedResultText(EntityEnum.Name, er, er);
                foreach (string ert in expectedResultListText)
                {
                    testSpecification.SetExpectedResultText(EntityEnum.Value, er, ert);
                    
                }
                foreach (string erc in expectedResultListCon)
                {
                    testSpecification.SetExpectedResultText(EntityEnum.Condition, er, erc);
                }
            }
            */
            String path = Server.MapPath("~/Specifications");
            String fileName = Path.GetFileName("TestSpecificationFile.Json");
            String fullPath = Path.Combine(path, fileName);
            testSpecification.WriteSpecification(fullPath);
            return View(testSpecification);
        }

        public FileResult Download()
        {
            String path = Server.MapPath("~/Specifications");
            String fileName = Path.GetFileName("TestSpecificationFile.json");
            String fullPath = Path.Combine(path, fileName);
            return File(fullPath, "file/Json", "TestSpecificationFile.json");
        }

        [HttpPost]
        public ActionResult Resources()
        {
            return View();
        }

        /* public ActionResult InputParameter(InputParameter testSpecification)
         {
             testSpecification.NewExpectedResult(Request.Form["name"]);
             testSpecification.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["given"]);
             testSpecification.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["value"]);
             testSpecification.SetExpectedResultText(EntityEnum.Given, Request.Form["name"], Request.Form["condition"]);
             return View();
         }*/

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