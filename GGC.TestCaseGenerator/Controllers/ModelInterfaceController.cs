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
        public CoverageGroup CreateCoverageGroup(string groupName, string members)
        {
            //Need validation if parameters are empty or not
           this.group.Name = groupName;
           this.group.Parameters = Split(members);
        
            return this.group;
        }

        //splits the string coming from the user to populate members array
        public IList<string> Split(string members)
        {          
            IList<string> memberSplitList = members.Split(',').ToList();          
            return memberSplitList;
        }

        public IList<string> AddMembers(string member)
        {
            IList<string> test = new List<string>();
            int index = member.Length - 1;
            char memberLastDigit = member[index];
            index = memberLastDigit - '0';
          
            for(int i = 0; i < index; i++)
            {

            }

            return test;
        }
        
        //method to turn test specification object into json script
    }
}