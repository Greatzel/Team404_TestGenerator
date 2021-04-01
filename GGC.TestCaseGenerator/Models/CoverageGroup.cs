using System;
using System.Collections;
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
        public CoverageGroup(string name, ArrayList parameters)
        {
            Name = name;
            Parameters = (IList<string>)parameters;
        }       
      
        //Sets the data of members of the class and 
        //returns true if successful
        public bool Set(string name, IList<string> parameters)
        {
            Name = name;
            Parameters = parameters;
            return true;
        }

        public void Split(String members)
        {

        }

        /*In Jim's original code, at this point there is an XML reader.
            but since we are not going to save test specifications in XML
            but in JSON instead, then I will leave it out.*/

        //---Q: Why is there no ReadAsJSON in this class? 

        //Checks if test specification coverage group has input parameters or not
        public bool Validate(IList<string> errors)
        {
            bool validated = true;
            if((Parameters == null) || !Parameters.Any())
            {
                errors.Add($"Coverage group {Name} has no parameters");
                validated = false;
            }
            return validated;
        }
    }
}