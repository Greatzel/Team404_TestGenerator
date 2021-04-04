using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Controllers
{
    /// <summary>
    /// Enumerates different types of entities that exist within test specifications.
    /// </summary>
    public enum EntityEnum
    {
        None,
        Given,
        Name,
        Description,
        Value,
        Condition
    }
    public class ModelInterfaceController
    {
        private Models.TestSpecification testSpecification;

        private string savedTestSpecificationAsJson;

        public ModelInterfaceController()
        {
            Reset();
        }

        public void Reset()
        {
            testSpecification = null;
            savedTestSpecificationAsJson = null;
        }

        /// <summary>
        /// Sets the current, working test specification.
        /// </summary>
        public void SetTestSpecification(Models.TestSpecification specification)
        {
            testSpecification = specification;
        }

        /// <summary>
        /// Sets the saved (or original) version of the test specification as a JSON text string.
        /// </summary>
        public void SetSavedSpecification(Models.TestSpecification specification)
        {
            savedTestSpecificationAsJson = (specification == null) ? null : JsonConvert.SerializeObject(specification);
        }

        /// <summary>
        /// Creates a new test specification and sets the working and saved versions to it.
        /// </summary>
        public void SetNewSpecificationAndName(string newSpecificationName)
        {
            testSpecification = new Models.TestSpecification();
            testSpecification.Name = newSpecificationName;
            savedTestSpecificationAsJson = JsonConvert.SerializeObject(testSpecification);
        }

        /// <summary>
        /// Returns the current Test Specification
        /// </summary>
        /// <returns>testSpecification</returns>
        public Models.TestSpecification GetTestSpecification()
        {
            return testSpecification;
        }

        public string GetTestSpecidicationAsJson()
        {
            if((testSpecification == null) || 
                ((testSpecification.Given == null) && 
                (testSpecification.Name == null) && 
                (testSpecification.Text == null) &&
                (testSpecification.CoverageGroups == null) &&
                (testSpecification.InputParameters == null) &&
                (testSpecification.ExpectedResults == null)))
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(testSpecification, Formatting.Indented);
        }

        /// <summary>
        /// Returns the parameter object from the specification given the name
        /// </summary>
        public Models.InputParameter GetInputParameter(string parameterName)
        {
            if ((testSpecification == null) ||
                (testSpecification.InputParameters == null) ||
                !testSpecification.InputParameters.ContainsKey(parameterName))
            {
                return null;
            }

            return testSpecification.InputParameters[parameterName];
        }

        /// <summary>
        /// Returns the equivalence class object from the specification given the name
        /// </summary>
        public Models.EquivalenceClass GetEquivalenceClass(string parameterName, string equivalenceClassName)
        {
            Models.InputParameter inputParameter = GetInputParameter(parameterName);
            if ((inputParameter == null) ||
                (inputParameter.EquivalenceClasses == null) ||
                !inputParameter.EquivalenceClasses.ContainsKey(equivalenceClassName))
            {
                return null;
            }

            return inputParameter.EquivalenceClasses[equivalenceClassName];
        }

        /// <summary>
        /// Returns the expeceted results object from the specification given the name
        /// </summary>
        public Models.ExpectedResult GetExpectedResult(string expectedResultName)
        {
            if ((testSpecification == null) ||
                (testSpecification.ExpectedResults == null) ||
                !testSpecification.ExpectedResults.ContainsKey(expectedResultName))
            {
                return null;
            }

            return testSpecification.ExpectedResults[expectedResultName];
        }

        /// <summary>
        /// Returns the coverage group object
        /// </summary>
        public Models.CoverageGroup GetCoverageGroup(string coverageGroupName)
        {
            if ((testSpecification == null) ||
                (testSpecification.CoverageGroups == null))
            {
                return null;
            }

            IList<Models.CoverageGroup> coverageGroups = testSpecification.CoverageGroups
                .Where(x => x.Name == coverageGroupName).ToList();
            return (coverageGroups == null) || !coverageGroups.Any() ? null : coverageGroups[0];
        }

        /// <summary>
        /// Creates a new input parameter with the given name and returns true if successful.
        /// </summary>
        public bool NewInputParameter(string inputParameterName)
        {
            if (testSpecification == null)
            {
                return false;
            }

            if (testSpecification.InputParameters == null)
            {
                testSpecification.InputParameters = new Dictionary<string, Models.InputParameter>();
            }

            Models.InputParameter inputParameter = new Models.InputParameter();
            inputParameter.Name = inputParameterName;
            testSpecification.InputParameters.Add(inputParameterName, inputParameter);
            return true;
        }

        /// <summary>
        /// Creates a parameter's new equivalence class with the given name and returns true if successful.
        /// </summary>
        public bool NewEquivalenceClass(string inputParameterName, string equivalenceClassName)
        {
            Models.InputParameter inputParameter = GetInputParameter(inputParameterName);
            if (inputParameter == null)
            {
                return false;
            }

            if (inputParameter.EquivalenceClasses == null)
            {
                inputParameter.EquivalenceClasses = new Dictionary<string, Models.EquivalenceClass>();
            }

            Models.EquivalenceClass equivalenceClass = new Models.EquivalenceClass();
            equivalenceClass.Name = equivalenceClassName;
            inputParameter.EquivalenceClasses.Add(equivalenceClassName, equivalenceClass);
            return true;
        }

        /// <summary>
        /// Creates a new expected result with the given name and returns true if successful.
        /// </summary>
        public bool NewExpectedResult(string expectedResultName)
        {
            if (testSpecification == null)
            {
                return false;
            }

            if (testSpecification.ExpectedResults == null)
            {
                testSpecification.ExpectedResults = new Dictionary<string, Models.ExpectedResult>();
            }

            Models.ExpectedResult expectedResult = new Models.ExpectedResult();
            expectedResult.Name = expectedResultName;
            testSpecification.ExpectedResults.Add(expectedResultName, expectedResult);
            return true;
        }

        /// <summary>
        /// Creates a new coverage group with the given name and returns true if successful.
        /// </summary>
        public bool NewCoverageGroup(string coverageGroupName)
        {
            if (testSpecification == null)
            {
                return false;
            }

            if (testSpecification.CoverageGroups == null)
            {
                testSpecification.CoverageGroups = new List<Models.CoverageGroup>();
            }

            Models.CoverageGroup coverageGroup = new Models.CoverageGroup();
            coverageGroup.Name = coverageGroupName;
            testSpecification.CoverageGroups.Add(coverageGroup);
            return true;
        }

        /// <summary>
        /// Creates a coverage group's new parameter with the given name and returns true if successful.
        /// </summary>
        public bool NewCoverageGroupInputParameter(string coverageGroupName, string newInputParameterName)
        {
            Models.CoverageGroup coverageGroup = GetCoverageGroup(coverageGroupName);
            if (coverageGroup == null)
            {
                return false;
            }

            if (coverageGroup.Parameters == null)
            {
                coverageGroup.Parameters = new List<string>();
            }

            coverageGroup.Parameters.Add(newInputParameterName);

            if (testSpecification.SpecificationDependencies == null)
            {
                testSpecification.UpdateDependencies();
            }
            else
            {
                testSpecification.SpecificationDependencies.NewCoverageGroupReferences(
                    coverageGroupName, coverageGroup.Parameters);
            }

            return true;
        }

        /// <summary>
        /// Sets the value of one of the text attributes in the working specification.
        /// </summary>
        public void SetSpecificationText(EntityEnum entity, string text)
        {
            switch (entity)
            {
                case EntityEnum.Given:
                    testSpecification.Given = text;
                    break;
                case EntityEnum.Name:
                    testSpecification.Name = text;
                    break;
                case EntityEnum.Description:
                    testSpecification.Text = text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the value of one of the text attributes in the input parameter of the given name.
        /// </summary>
        public void SetInputParameterText(EntityEnum entity, string parameterName, string text)
        {
            Models.InputParameter inputParameter = GetInputParameter(parameterName);
            if (inputParameter == null)
            {
                return;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    inputParameter.Given = text;
                    break;
                case EntityEnum.Name:
                    inputParameter.Name = text;
                    break;
                case EntityEnum.Value:
                    inputParameter.Text = text;
                    break;
                case EntityEnum.Condition:
                    inputParameter.Condition = text;
                    inputParameter.ParseConditions();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the value of one of the text attributes in the parameter's equivalence class of the given name.
        /// </summary>
        public void SetEquivalenceClassText(EntityEnum entity, string parameterName, string equivalenceClassName, string text)
        {
            Models.EquivalenceClass equivalenceClass = GetEquivalenceClass(parameterName, equivalenceClassName);
            if (equivalenceClass == null)
            {
                return;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    equivalenceClass.Given = text;
                    break;
                case EntityEnum.Name:
                    equivalenceClass.Name = text;
                    break;
                case EntityEnum.Value:
                    equivalenceClass.Text = text;
                    break;
                case EntityEnum.Condition:
                    equivalenceClass.Condition = text;
                    equivalenceClass.ParseConditions();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the value of one of the text attributes in the expected result of the given name.
        /// </summary>
        public void SetExpectedResultText(EntityEnum entity, string expectedResultName, string text)
        {
            Models.ExpectedResult expectedResult = GetExpectedResult(expectedResultName);
            if (expectedResult == null)
            {
                return;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    expectedResult.Given = text;
                    break;
                case EntityEnum.Name:
                    expectedResult.Name = text;
                    break;
                case EntityEnum.Value:
                    expectedResult.Text = text;
                    break;
                case EntityEnum.Condition:
                    expectedResult.Condition = text;
                    expectedResult.ParseConditions();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// writes the current working specification to an output file
        /// </summary>
        /// <param name="specificationFileName"></param>
        public bool WriteSpecification(string specificationFileName)
        {
            testSpecification.Clear();
            bool written = Helpers.FileHelper.WriteAsJson(specificationFileName, testSpecification);
            //testSpecification.Normalize();
            return written;
        }
    }
}