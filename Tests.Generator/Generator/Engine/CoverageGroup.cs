//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  05/24/2017
//// Reason:
////     ULTI-249839: Write a tool to generate test cases from an XML specification.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Generator.Helpers;

namespace Generator.Engine
{
    /// <summary>
    /// Class that encapsulates a list of parameters used for coverage.
    /// </summary>
    public class CoverageGroup
    {
        /// <summary>
        /// The name of the coverage group from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ordered list of 1 or more parameters comprising the coverage group.
        /// </summary>
        public IList<string> Parameters { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class CoverageGroup.
        /// </summary>
        public CoverageGroup()
        {
            Name = null;
            Parameters = null;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(string name, IList<string> parameters)
        {
            Name = name;
            Parameters = parameters;
            return true;
        }

        /// <summary>
        /// Reads the XML element for the coverage group and returns true if successful.
        /// </summary>
        public bool ReadAsXml(XElement xCoverageGroup)
        {
            string name = TestSpecification.XmlField(xCoverageGroup, "Name");
            IList<string> parameters = new List<string>();
            foreach (XElement xParameter in XmlHelper.Children(xCoverageGroup, "Parameter"))
            {
                string parameterName = TestSpecification.FieldsAsAttributes
                    ? XmlHelper.AttributeOf(xParameter, "Name")
                    : xParameter.Value;
                parameters.Add(parameterName);
            }

            return Set(name, parameters);
        }

        /// <summary>
        /// Validates the test specification and returns true if successful; otherwise false
        /// and returns an informative error message.
        /// </summary>
        public bool Validate(IList<string> errors)
        {
            bool validated = true;
            if ((Parameters == null) || !Parameters.Any())
            {
                errors.Add($"Coverage group {Name} has no parameters");
                validated = false;
            }

            return validated;
        }
    }
}
