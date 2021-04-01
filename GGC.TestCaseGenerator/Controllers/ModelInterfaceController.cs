using GGC.TestCaseGenerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GGC.TestCaseGenerator.Controllers
{
    public class ModelInterfaceController : Controller
    {
        //public TestSpecification TestSpecifaciont1
        CoverageGroup group = new CoverageGroup();

        // GET: ModelInterface
        public ActionResult Index()
        {
            return View();
        }

        //method that returns a list of coverage groups from the user input
        public String CreateCoverageGroup(string groupName, string members)
        {
            string result = "Coverage group submitted";

            //Need validation if parameters are empty or not
            group.Name = groupName;
            group.Parameters = Split(members);

            ToJsonFile(group);
            return result;
        }

        //splits the string coming from the user to populate members array
        public IList<string> Split(string members)
        {
            string[] memberSplitList = members.Split(',');
            IList<string> membersArray = new List<string>();

            foreach (var member in memberSplitList)
            {
                membersArray.Add(member);
            }

            return membersArray;
        }

        //method to turn test specification object into json script

        public void ToJsonFile(CoverageGroup coveragegroup)
        {
            string jsondata = new JavaScriptSerializer().Serialize(coveragegroup);
            string filePath = Server.MapPath("~/App_Data/");
            System.IO.File.WriteAllText(filePath + "testOutput.json", jsondata);        
        }

    }
}