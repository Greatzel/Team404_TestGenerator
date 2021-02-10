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
using Newtonsoft.Json;

namespace Generator.Engine
{
    /// <summary>
    /// Class that encapsulates an XML test specification.
    /// </summary>
    public class TestSpecification
    {
        /// <summary>
        /// Specifies text for the GIVEN constraint on the specification.
        /// </summary>
        public string Given { get; set; }

        /// <summary>
        /// The name of the test specification from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the test specification from the XML file.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A list of 0 or more coverage groups in the test specification.
        /// </summary>
        public IList<CoverageGroup> CoverageGroups { get; set; }

        /// <summary>
        /// A mapping of parameter names onto the structures containing their data.
        /// </summary>
        public IDictionary<string, InputParameter> InputParameters { get; set; }

        /// <summary>
        /// A mapping of result names onto the structures containing their data.
        /// </summary>
        public IDictionary<string, ExpectedResult> ExpectedResults { get; set; }

        /// <summary>
        /// Enumerates all of the "X uses Y" dependencies in the test specification.
        /// </summary>
        public Dependencies SpecificationDependencies { get; set; }

        /// <summary>
        /// True if the fields within a test specification are represented as attributes,
        /// otherwise false (and they're represented as elements).
        /// </summary>
        public static bool FieldsAsAttributes = false;

        /// <summary>
        /// Returns the value of a field in an XML element, whether representated
        /// as an attribute or as an element.
        /// </summary>
        public static string XmlField(XElement element, string attribute)
        {
            return (TestSpecification.FieldsAsAttributes)
                ? XmlHelper.AttributeOf(element, attribute)
                : XmlHelper.ElementOf(element, attribute);
        }

        /// <summary>
        /// Constructs and initializes an instance object of the class TestSpecification.
        /// </summary>
        public TestSpecification()
        {
            Given = null;
            Name = null;
            Text = null;
            CoverageGroups = null;
            InputParameters = null;
            ExpectedResults = null;
            SpecificationDependencies = null;
        }

        /// <summary>
        /// Constructs, initializes, and populates an instance object of the class TestSpecification.
        /// </summary>
        public TestSpecification(string specificationFilename)
        {
            Given = null;
            Name = null;
            Text = null;
            CoverageGroups = null;
            InputParameters = null;
            ExpectedResults = null;
            SpecificationDependencies = null;

            ReadAsJson(specificationFilename);
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(
            string given,
            string name,
            string text,
            IList<CoverageGroup> coverageGroups,
            IDictionary<string, InputParameter> inputParameters,
            IDictionary<string, ExpectedResult> expectedResults)
        {
            Given = given;
            Name = name;
            Text = text;
            CoverageGroups = coverageGroups;
            InputParameters = inputParameters;
            ExpectedResults = expectedResults;
            return true;
        }

        /// <summary>
        /// Reads the JSON contents of the file into the test specification and returns true if successful.
        /// </summary>
        public bool ReadAsJson(string filenameWithPath)
        {
            string contentsAsString = FileHelper.ContentsAsString(filenameWithPath);
            TestSpecification specification = JsonConvert.DeserializeObject<TestSpecification>(contentsAsString);
            if (specification == null)
            {
                return false;
            }

            bool compositeRead = Set(
                specification.Given, specification.Name, specification.Text, specification.CoverageGroups,
                specification.InputParameters, specification.ExpectedResults);
            compositeRead = compositeRead && Normalize();
            compositeRead = compositeRead && UpdateDependencies();
            return compositeRead;
        }

        /// <summary>
        /// Reads the XML contents of the file into the test specification and returns true if successful.
        /// </summary>
        public bool ReadAsXml(string filenameWithPath)
        {
            string contentsAsString = FileHelper.ContentsAsString(filenameWithPath);
            XElement xTestSpecification = XmlHelper.Root(contentsAsString, "TestSpecification");

            FieldsAsAttributes = XmlHelper.ElementOf(xTestSpecification, "FieldsAsAttributes") == "true";
            string given = XmlField(xTestSpecification, "Given");
            string name = XmlField(xTestSpecification, "Name");
            string text = XmlField(xTestSpecification, "Text");

            IList<CoverageGroup> coverageGroups = new List<CoverageGroup>();
            foreach (XElement xCoverageGroup in XmlHelper.Children(xTestSpecification, "CoverageGroup"))
            {
                CoverageGroup coverageGroup = new CoverageGroup();
                if (coverageGroup.ReadAsXml(xCoverageGroup))
                {
                    coverageGroups.Add(coverageGroup);
                }
            }

            IDictionary<string, InputParameter> inputParameters = new Dictionary<string, InputParameter>();
            foreach (XElement xInputParameter in XmlHelper.Children(xTestSpecification, "InputParameter"))
            {
                InputParameter inputParameter = new InputParameter();
                if (inputParameter.ReadAsXml(xInputParameter) && !inputParameters.ContainsKey(inputParameter.Name))
                {
                    inputParameters.Add(inputParameter.Name, inputParameter);
                }
            }

            IDictionary<string, ExpectedResult> expectedResults = new Dictionary<string, ExpectedResult>();
            foreach (XElement xExpectedResult in XmlHelper.Children(xTestSpecification, "ExpectedResult"))
            {
                ExpectedResult expectedResult = new ExpectedResult();
                if (expectedResult.ReadAsXml(xExpectedResult) && !expectedResults.ContainsKey(expectedResult.Name))
                {
                    expectedResults.Add(expectedResult.Name, expectedResult);
                }
            }

            bool compositeRead = Set(given, name, text, coverageGroups, inputParameters, expectedResults);
            compositeRead = compositeRead && Normalize();
            compositeRead = compositeRead && UpdateDependencies();
            return compositeRead;
        }

        /// <summary>
        /// Saves all of the dependencies in the test specification.
        /// </summary>
        public bool UpdateDependencies()
        {
            SpecificationDependencies = new Dependencies();
            if (InputParameters != null)
            {
                foreach (InputParameter parameter in InputParameters.Values)
                {
                    SpecificationDependencies.NewInputParameterReferences(parameter.Name,
                        parameter.ConditionExpression);
                    if (parameter.EquivalenceClasses != null)
                    {
                        foreach (EquivalenceClass equivalenceClass in parameter.EquivalenceClasses.Values)
                        {
                            SpecificationDependencies.NewEquivalenceClassReferences(
                                parameter.Name, equivalenceClass.Name, equivalenceClass.ConditionExpression);
                        }
                    }
                }
            }

            if (ExpectedResults != null)
            {
                foreach (ExpectedResult expectedResult in ExpectedResults.Values)
                {
                    SpecificationDependencies.NewExpectedResultReferences(expectedResult.Name,
                        expectedResult.ConditionExpression);
                }
            }

            if (CoverageGroups != null)
            {
                foreach (CoverageGroup coverageGroup in CoverageGroups)
                {
                    SpecificationDependencies.NewCoverageGroupReferences(coverageGroup.Name, coverageGroup.Parameters);
                }
            }

            return true;
        }

        /// <summary>
        /// Returns true if the given parameter is consumed by other objects, along with
        /// a message detailing its uses (otherwise returns false and a null string).
        /// </summary>
        public bool InputParameterIsConsumed(string parameter, out string consumers)
        {
            if (SpecificationDependencies == null)
            {
                consumers = null;
                return false;
            }

            return SpecificationDependencies.InputParameterIsConsumed(parameter, out consumers);
        }

        /// <summary>
        /// Returns true if the given equivalence class is consumed by other objects, along
        /// with a message detailing its uses (otherwise returns false and a null string).
        /// </summary>
        public bool EquivalenceClassIsConsumed(string parameter, string equivalenceClass, out string consumers)
        {
            if (SpecificationDependencies == null)
            {
                consumers = null;
                return false;
            }

            return SpecificationDependencies.EquivalenceClassIsConsumed(parameter, equivalenceClass, out consumers);
        }

        /// <summary>
        /// Returns the list of coverage group names.
        /// </summary>
        public IList<string> CoverageGroupNames()
        {
            if ((CoverageGroups == null) || !CoverageGroups.Any())
            {
                return new List<string>();
            }

            return CoverageGroups.Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Clears the expressions and coverage groups; returns true if both are successful.
        /// </summary>
        public bool Clear()
        {
            return ClearCoverage() && ClearExpressions();
        }

        /// <summary>
        /// Normalizes the expressions and coverage groups; returns true if both are successful.
        /// </summary>
        public bool Normalize()
        {
            return NormalizeCoverage() && NormalizeExpressions();
        }

        /// <summary>
        /// Validates the test specification and returns true if successful; otherwise false
        /// and returns an informative error message.
        /// </summary>
        public bool Validate(IList<string> errors)
        {
            bool validated = true;
            if ((InputParameters == null) || !InputParameters.Any())
            {
                errors.Add($"specification {Name} has no input parameters");
                validated = false;
            }
            else foreach (InputParameter parameter in InputParameters.Values)
            {
                validated = parameter.Validate(errors) && validated;
            }

            if ((ExpectedResults == null) || !ExpectedResults.Any())
            {
                errors.Add($"specification {Name} has no expected results");
                validated = false;
            }
            else foreach (ExpectedResult expectedResult in ExpectedResults.Values)
            {
                validated = expectedResult.Validate(errors) && validated;
            }

            if ((CoverageGroups == null) || !CoverageGroups.Any())
            {
                errors.Add($"specification {Name} has no coverage groups");
                validated = false;
            }
            else foreach (CoverageGroup coverageGroup in CoverageGroups)
            {
                validated = coverageGroup.Validate(errors) && validated;
            }

            return validated && (errors.Count == 0);
        }

        /// <summary>
        /// Ensures that every parameter is referenced at least once in a coverage group. If
        /// not, it adds coverage groups for those that are unused to the specification.
        /// Returns true if successful.
        /// </summary>
        private bool NormalizeCoverage()
        {
            IDictionary<string, bool> parametersCovered = new Dictionary<string, bool>();
            foreach (string parameter in InputParameters.Keys)
            {
                parametersCovered.Add(parameter, false);
            }

            if (CoverageGroups == null)
            {
                CoverageGroups = new List<CoverageGroup>();
            }

            foreach (CoverageGroup coverageGroup in CoverageGroups)
            {
                foreach (string parameter in coverageGroup.Parameters)
                {
                    parametersCovered[parameter] = true;
                }
            }

            foreach (string parameter in parametersCovered.Keys.Where(x => !parametersCovered[x]))
            {
                CoverageGroup coverageGroup = new CoverageGroup();
                coverageGroup.Set($"Singleton-{parameter}", new List<string> { parameter });
                CoverageGroups.Add(coverageGroup);
            }

            return true;
        }

        /// <summary>
        /// Parses strings containing expressions into recursive expression objects; returns true if successful.
        /// </summary>
        private bool NormalizeExpressions()
        {
            bool compositeResult = true;
            if ((InputParameters != null) && InputParameters.Any())
            {
                foreach (InputParameter parameter in InputParameters.Values)
                {
                    if (!parameter.ParseConditions())
                    {
                        compositeResult = false;
                    }

                    if ((parameter.EquivalenceClasses != null) && parameter.EquivalenceClasses.Any())
                    {
                        foreach (EquivalenceClass equivalenceClass in parameter.EquivalenceClasses.Values)
                        {
                            if (!equivalenceClass.ParseConditions())
                            {
                                compositeResult = false;
                            }
                        }
                    }
                }
            }

            if ((ExpectedResults != null) && ExpectedResults.Any())
            {
                foreach (ExpectedResult result in ExpectedResults.Values)
                {
                    if (!result.ParseConditions())
                    {
                        compositeResult = false;
                    }
                }
            }

            return compositeResult;
        }

        /// <summary>
        /// Removes any "singleton" coverage groups.
        /// </summary>
        private bool ClearCoverage()
        {
            if (CoverageGroups == null)
            {
                return true;
            }

            IList<CoverageGroup> filteredCoverageGroups = new List<CoverageGroup>();
            foreach (CoverageGroup coverageGroup in CoverageGroups.Where(x => !x.Name.StartsWith("Singleton-")))
            {
                filteredCoverageGroups.Add(coverageGroup);
            }

            CoverageGroups = filteredCoverageGroups;
            return true;
        }

        /// <summary>
        /// Removes the expression objects from parameters, equivalence classes, and expected results.
        /// </summary>
        private bool ClearExpressions()
        {
            bool compositeResult = true;
            if ((InputParameters != null) && InputParameters.Any())
            {
                foreach (InputParameter parameter in InputParameters.Values)
                {
                    parameter.ConditionExpression = null;
                    if ((parameter.EquivalenceClasses != null) && parameter.EquivalenceClasses.Any())
                    {
                        foreach (EquivalenceClass equivalenceClass in parameter.EquivalenceClasses.Values)
                        {
                            equivalenceClass.ConditionExpression = null;
                        }
                    }
                }
            }

            if ((ExpectedResults != null) && ExpectedResults.Any())
            {
                foreach (ExpectedResult result in ExpectedResults.Values)
                {
                    result.ConditionExpression = null;
                }
            }

            return compositeResult;
        }
    }
}
