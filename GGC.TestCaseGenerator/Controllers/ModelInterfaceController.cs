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
        //UPDATE: object will be commented out
        CoverageGroup group = new CoverageGroup();

        // GET: ModelInterface
        public ActionResult Index()
        {
            return View();
        }

        //method that returns a coverage group with a list of parameters from input
        //UPDATE: CreateCoverageGroup will be commented out
        public CoverageGroup CreateCoverageGroup(string groupName, string members)
        {
            //Need validation if parameters are empty or not
           group.Name = groupName;
          // group.Parameters = SplitString(members);
        
            return group;
            //Checkpoint
        }

        //splits the string coming from the user to populate members array
        public IList<string> SplitString(string members)
        {          
            IList<string> splitStringtoArray = members.Split(',').ToList();          
            return splitStringtoArray;
        }

        /*public IList<string> AddMembers(string member)
        {
            IList<string> test = new List<string>();
            int index = member.Length - 1;
            char memberLastDigit = member[index];
            index = memberLastDigit - '0';
          
            for(int i = 0; i < index; i++)
            {

            }

            return test;
        }*/
        
        //method to turn test specification object into json script
    }
}