using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    public class CoverageGroup
    {
        //Defining coverage group name
        public string Name { get; set; }

        //Define list of input parameters that make a coverage group

        public IList<string> Parameters { get; set; }

        //Defines a no arg constructor to initialize coverage group
        public CoverageGroup()
        {
            Name = null;
            Parameters = null;
        }

        //Sets the data of members of the class and returns true if successful
        public bool Set(string name, IList<string> parameters)
        {
            Name = name;
            Parameters = parameters;
            return true;
        }
    }
}