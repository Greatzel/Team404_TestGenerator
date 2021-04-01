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
    public class ModelInterface
    {
        /// <summary>
        /// Model object for the "working" test specification.
        /// </summary>
        private Models.TestSpecification workingTestSpecification;

        /// <summary>
        /// Model object for the "working" test generator.
        /// </summary>
        private Models.TestGenerator workingTestGenerator;

        /// <summary>
        /// JSON representation of the last saved (or original) version of the working
        /// test specification.
        /// </summary>
        private string savedTestSpecificationAsJson;

        /// <summary>
        /// Constructs and initializes an instance of class ModelInterface.
        /// </summary>
        public ModelInterface()
        {
            Reset();
        }

        /// <summary>
        /// Resets the data of the model.
        /// </summary>
        public void Reset()
        {
            workingTestSpecification = null;
            savedTestSpecificationAsJson = null;
            workingTestGenerator = null;
        }

        /// <summary>
        /// Sets the current, working test specification.
        /// </summary>
        public void SetWorkingSpecification(Models.TestSpecification specification)
        {
            workingTestSpecification = specification;
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
            workingTestSpecification = new Models.TestSpecification();
            workingTestSpecification.Name = newSpecificationName;
            savedTestSpecificationAsJson = JsonConvert.SerializeObject(workingTestSpecification);
        }

        /// <summary>
        /// Creates a new test specification from the contents of a file, and sets the
        /// working and saved versions of it.
        /// </summary>
        public void SetNewSpecificationFromFile(string specificationFilename)
        {
            workingTestSpecification = new Models.TestSpecification(specificationFilename);
            savedTestSpecificationAsJson = JsonConvert.SerializeObject(workingTestSpecification);
        }

        /// <summary>
        /// Returns the current working test specification.
        /// </summary>
        public Models.TestSpecification GetWorkingSpecification()
        {
            return workingTestSpecification;
        }

        /// <summary>
        /// Returns the current working test specification as a JSON string.
        /// </summary>
        public string GetWorkingSpecificationAsJson()
        {
            if ((workingTestSpecification == null) ||
                ((workingTestSpecification.Given == null) &&
                 (workingTestSpecification.Name == null) &&
                 (workingTestSpecification.Text == null) &&
                 (workingTestSpecification.CoverageGroups == null) &&
                 (workingTestSpecification.InputParameters == null) &&
                 (workingTestSpecification.ExpectedResults == null)))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(workingTestSpecification, Formatting.Indented);
        }

        /// <summary>
        /// Runs validation checks on the working test specification and returns
        /// true if successful, otherwise false with an informative error message.
        /// </summary>
        public bool ValidateSpecification(out string error)
        {
            if (workingTestSpecification == null)
            {
                error = "There is no test specification for generating a test script";
                return false;
            }

            IList<string> errors = new List<string>();
            if (!workingTestSpecification.Validate(errors))
            {
                error = string.Join("; ", errors);
                return false;
            }

            error = null;
            return true;
        }

        /// <summary>
        /// Returns true if the parameter with the given name exists in the working specification.
        /// </summary>
        public bool InputParameterExists(string parameterName)
        {
            return GetInputParameter(parameterName) != null;
        }

        /// <summary>
        /// Returns true if the parameter's equivalence class with the given name exists in the working specification.
        /// </summary>
        public bool EquivalenceClassExists(string parameterName, string equivalenceClassName)
        {
            return GetEquivalenceClass(parameterName, equivalenceClassName) != null;
        }

        /// <summary>
        /// Returns true if the expected result with the given name exists in the working specification.
        /// </summary>
        public bool ExpectedResultExists(string expectedResultName)
        {
            return GetExpectedResult(expectedResultName) != null;
        }

        /// <summary>
        /// Returns true if the coverage group with the given name exists in the working specification.
        /// </summary>
        public bool CoverageGroupExists(string coverageGroupName)
        {
            return GetCoverageGroup(coverageGroupName) != null;
        }

        /// <summary>
        /// Returns the parameter object from the working specification that has the given name
        /// (otherwise null).
        /// </summary>
        public Models.InputParameter GetInputParameter(string parameterName)
        {
            if ((workingTestSpecification == null) ||
                (workingTestSpecification.InputParameters == null) ||
                !workingTestSpecification.InputParameters.ContainsKey(parameterName))
            {
                return null;
            }

            return workingTestSpecification.InputParameters[parameterName];
        }

        /// <summary>
        /// Returns the parameter's equivalence class object from the working specification
        /// that has the given name (otherwise null).
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
        /// Returns the expected result object from the working specification that has
        /// the given name (otherwise null).
        /// </summary>
        public Models.ExpectedResult GetExpectedResult(string expectedResultName)
        {
            if ((workingTestSpecification == null) ||
                (workingTestSpecification.ExpectedResults == null) ||
                !workingTestSpecification.ExpectedResults.ContainsKey(expectedResultName))
            {
                return null;
            }

            return workingTestSpecification.ExpectedResults[expectedResultName];
        }

        /// <summary>
        /// Returns the coverage group object from the working specification that has
        /// the given name (otherwise null).
        /// </summary>
        public Models.CoverageGroup GetCoverageGroup(string coverageGroupName)
        {
            if ((workingTestSpecification == null) ||
                (workingTestSpecification.CoverageGroups == null))
            {
                return null;
            }

            IList<Models.CoverageGroup> coverageGroups = workingTestSpecification.CoverageGroups
                .Where(x => x.Name == coverageGroupName).ToList();
            return (coverageGroups == null) || !coverageGroups.Any() ? null : coverageGroups[0];
        }

        /// <summary>
        /// Returns true if the working specification exists.
        /// </summary>
        public bool WorkingSpecificationExists()
        {
            return workingTestSpecification != null;
        }

        /// <summary>
        /// Saves the current working specification internally as a JSON string.
        /// </summary>
        public void SaveSpecification()
        {
            savedTestSpecificationAsJson = JsonConvert.SerializeObject(workingTestSpecification);
        }

        /// <summary>
        /// Discards the current working specification and reverts it to the most recently saved version.
        /// </summary>
        public void DiscardSpecification()
        {
            workingTestSpecification = JsonConvert.DeserializeObject<Models.TestSpecification>(savedTestSpecificationAsJson);
        }

        /// <summary>
        /// Writes the current working specification to an output file and returns
        /// true if successful.
        /// </summary>
        public bool WriteSpecification(string specificationFilename)
        {
            workingTestSpecification.Clear();
            bool written = Helpers.FileHelper.WriteAsJson(specificationFilename, workingTestSpecification);
            workingTestSpecification.Normalize();
            return written;
        }

        /// <summary>
        /// Writes the generated test script to an output file and returns true if successful.
        /// </summary>
        public bool WriteScript(string scriptFilename)
        {
            if ((workingTestGenerator == null) ||
                (workingTestGenerator.GeneratedTestsInSuite == null))
            {
                return false;
            }

            return workingTestGenerator.GeneratedTestsInSuite.WriteToFile(scriptFilename);
        }

        /// <summary>
        /// Writes the generated test statistics to an output file and returns true if successful.
        /// </summary>
        public bool WriteStatistics(string statisticsFilename)
        {
            if ((workingTestGenerator == null) ||
                (workingTestGenerator.CoverageMetricsInSuite == null))
            {
                return false;
            }

            return workingTestGenerator.CoverageMetricsInSuite.WriteToFile(statisticsFilename);
        }

        /// <summary>
        /// Sets the value of one of the text attributes in the working specification.
        /// </summary>
        public void SetSpecificationText(EntityEnum entity, string text)
        {
            switch (entity)
            {
                case EntityEnum.Given:
                    workingTestSpecification.Given = text;
                    break;
                case EntityEnum.Name:
                    workingTestSpecification.Name = text;
                    break;
                case EntityEnum.Description:
                    workingTestSpecification.Text = text;
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
        /// Returns the value of one of the text attributes from the working specification.
        /// </summary>
        public string GetSpecificationText(EntityEnum entity, Models.TestSpecification specification)
        {
            if (specification == null)
            {
                return string.Empty;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    return workingTestSpecification.Given;
                case EntityEnum.Name:
                    return workingTestSpecification.Name;
                case EntityEnum.Description:
                    return workingTestSpecification.Text;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Returns the value of one of the text attributes from the input parameter of the given name.
        /// </summary>
        public string GetInputParameterText(EntityEnum entity, Models.InputParameter inputParameter)
        {
            if (inputParameter == null)
            {
                return string.Empty;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    return (inputParameter.Given == null) ? string.Empty : inputParameter.Given;
                case EntityEnum.Name:
                    return (inputParameter.Name == null) ? string.Empty : inputParameter.Name;
                case EntityEnum.Value:
                    return (inputParameter.Text == null) ? string.Empty : inputParameter.Text;
                case EntityEnum.Condition:
                    return (inputParameter.Condition == null) ? string.Empty : inputParameter.Condition;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Returns the value of one of the text attributes from the parameter's equivalence class of the given name.
        /// </summary>
        public string GetEquivalenceClassText(EntityEnum entity, Models.EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null)
            {
                return string.Empty;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    return (equivalenceClass.Given == null) ? string.Empty : equivalenceClass.Given;
                case EntityEnum.Name:
                    return (equivalenceClass.Name == null) ? string.Empty : equivalenceClass.Name;
                case EntityEnum.Value:
                    return (equivalenceClass.Text == null) ? string.Empty : equivalenceClass.Text;
                case EntityEnum.Condition:
                    return (equivalenceClass.Condition == null) ? string.Empty : equivalenceClass.Condition;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Returns the value of one of the text attributes from the expected result of the given name.
        /// </summary>
        public string GetExpectedResultText(EntityEnum entity, Models.ExpectedResult expectedResult)
        {
            if (expectedResult == null)
            {
                return string.Empty;
            }

            switch (entity)
            {
                case EntityEnum.Given:
                    return (expectedResult.Given == null) ? string.Empty : expectedResult.Given;
                case EntityEnum.Name:
                    return (expectedResult.Name == null) ? string.Empty : expectedResult.Name;
                case EntityEnum.Value:
                    return (expectedResult.Text == null) ? string.Empty : expectedResult.Text;
                case EntityEnum.Condition:
                    return (expectedResult.Condition == null) ? string.Empty : expectedResult.Condition;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Returns the array of input parameter names in the working specification.
        /// </summary>
        public string[] InputParameterNames()
        {
            if ((workingTestSpecification == null) || (workingTestSpecification.InputParameters == null))
            {
                return new List<string>().ToArray();
            }

            return workingTestSpecification.InputParameters.Keys.ToArray();
        }

        /// <summary>
        /// Returns the array of equivalence class names in the given parameter.
        /// </summary>
        public string[] EquivalenceClassNames(string parameterName)
        {
            if ((workingTestSpecification == null) ||
                (workingTestSpecification.InputParameters == null) ||
                string.IsNullOrEmpty(parameterName))
            {
                return new List<string>().ToArray();
            }

            Models.InputParameter inputParameter = workingTestSpecification.InputParameters[parameterName];
            if ((inputParameter == null) || (inputParameter.EquivalenceClasses == null))
            {
                return new List<string>().ToArray();
            }

            return inputParameter.EquivalenceClasses.Keys.ToArray();
        }

        /// <summary>
        /// Returns the array of expected result names in the working specification.
        /// </summary>
        public string[] ExpectedResultNames()
        {
            if ((workingTestSpecification == null) || (workingTestSpecification.ExpectedResults == null))
            {
                return new List<string>().ToArray();
            }

            return workingTestSpecification.ExpectedResults.Keys.ToArray();
        }

        /// <summary>
        /// Returns the array of coverage group names in the working specification.
        /// </summary>
        public string[] CoverageGroupNames()
        {
            if (workingTestSpecification == null)
            {
                return new List<string>().ToArray();
            }

            return workingTestSpecification.CoverageGroupNames().ToArray();
        }

        /// <summary>
        /// Returns the array of input parameter names in the given coverage group.
        /// </summary>
        public string[] CoverageGroupParameterNames(string coverageGroupName)
        {
            if ((workingTestSpecification == null) ||
                (workingTestSpecification.CoverageGroups == null) ||
                string.IsNullOrEmpty(coverageGroupName))
            {
                return new List<string>().ToArray();
            }

            IList<Models.CoverageGroup> coverageGroups =
                workingTestSpecification.CoverageGroups.Where(x => coverageGroupName == x.Name).ToList();
            if ((coverageGroups == null) || (coverageGroups.Count != 1) || (coverageGroups[0].Parameters == null))
            {
                return new List<string>().ToArray();
            }

            return coverageGroups[0].Parameters.ToArray();
        }

        /// <summary>
        /// Returns an array of generated test case names in written form.
        /// </summary>
        public string[] GeneratedTestCaseNames(bool consistentTestsOnly)
        {
            if ((workingTestGenerator == null) ||
                (workingTestGenerator.GeneratedTestsInSuite == null) ||
                (workingTestGenerator.GeneratedTestsInSuite.TestCases == null) ||
                !workingTestGenerator.GeneratedTestsInSuite.TestCases.Any())
            {
                return new List<string>().ToArray();
            }

            IList<Models.TestCase> requestedTestCases = workingTestGenerator.GeneratedTestsInSuite.TestCases;
            if (consistentTestsOnly)
            {
                requestedTestCases = requestedTestCases.Where(x => !string.IsNullOrEmpty(x.WrittenForm)).ToList();
            }

            return requestedTestCases.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Returns true if the parameter is consumed by other entities in the test
        /// specification. Also returns an informative message.
        /// </summary>
        public bool InputParameterIsConsumed(string parameterName, out string consumers)
        {
            if (workingTestSpecification == null)
            {
                consumers = null;
                return false;
            }

            return workingTestSpecification.InputParameterIsConsumed(parameterName, out consumers);
        }

        /// <summary>
        /// Returns true if the parameter's equivalence class is consumed by other entities
        /// in the test specification. Also returns an informative message.
        /// </summary>
        public bool EquivalenceClassIsConsumed(string parameterName, string equivalenceClassName, out string consumers)
        {
            if (workingTestSpecification == null)
            {
                consumers = null;
                return false;
            }

            return workingTestSpecification.EquivalenceClassIsConsumed(parameterName, equivalenceClassName, out consumers);
        }

        /// <summary>
        /// Creates a new input parameter with the given name and returns true if successful.
        /// </summary>
        public bool NewInputParameter(string inputParameterName)
        {
            if (workingTestSpecification == null)
            {
                return false;
            }

            if (workingTestSpecification.InputParameters == null)
            {
                workingTestSpecification.InputParameters = new Dictionary<string, Models.InputParameter>();
            }

            Models.InputParameter inputParameter = new Models.InputParameter();
            inputParameter.Name = inputParameterName;
            workingTestSpecification.InputParameters.Add(inputParameterName, inputParameter);
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
            if (workingTestSpecification == null)
            {
                return false;
            }

            if (workingTestSpecification.ExpectedResults == null)
            {
                workingTestSpecification.ExpectedResults = new Dictionary<string, Models.ExpectedResult>();
            }

            Models.ExpectedResult expectedResult = new Models.ExpectedResult();
            expectedResult.Name = expectedResultName;
            workingTestSpecification.ExpectedResults.Add(expectedResultName, expectedResult);
            return true;
        }

        /// <summary>
        /// Creates a new coverage group with the given name and returns true if successful.
        /// </summary>
        public bool NewCoverageGroup(string coverageGroupName)
        {
            if (workingTestSpecification == null)
            {
                return false;
            }

            if (workingTestSpecification.CoverageGroups == null)
            {
                workingTestSpecification.CoverageGroups = new List<Models.CoverageGroup>();
            }

            Models.CoverageGroup coverageGroup = new Models.CoverageGroup();
            coverageGroup.Name = coverageGroupName;
            workingTestSpecification.CoverageGroups.Add(coverageGroup);
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

            if (workingTestSpecification.SpecificationDependencies == null)
            {
                workingTestSpecification.UpdateDependencies();
            }
            else
            {
                workingTestSpecification.SpecificationDependencies.NewCoverageGroupReferences(
                    coverageGroupName, coverageGroup.Parameters);
            }

            return true;
        }

        /// <summary>
        /// Deletes the input parameter from the specification and returns true if successful.
        /// </summary>
        public bool DeleteInputParameter(string parameterName)
        {
            Models.InputParameter inputParameter = GetInputParameter(parameterName);
            if (inputParameter == null)
            {
                return false;
            }

            workingTestSpecification.InputParameters.Remove(parameterName);
            workingTestSpecification.SpecificationDependencies.DeleteInputParameterReferences(parameterName);
            return true;
        }

        /// <summary>
        /// Deletes the parameter's equivalence class from the specification and returns true if successful.
        /// </summary>
        public bool DeleteEquivalenceClass(string parameterName, string equivalenceClassName)
        {
            Models.EquivalenceClass equivalenceClass = GetEquivalenceClass(parameterName, equivalenceClassName);
            if (equivalenceClass == null)
            {
                return false;
            }

            workingTestSpecification
                .InputParameters[parameterName]
                .EquivalenceClasses.Remove(equivalenceClassName);
            if (workingTestSpecification.SpecificationDependencies != null)
            {
                workingTestSpecification.SpecificationDependencies.DeleteEquivalenceClassReferences(
                    parameterName, equivalenceClassName);
            }

            return true;
        }

        /// <summary>
        /// Deletes the coverage group from the specification and returns true if successful.
        /// </summary>
        public bool DeleteCoverageGroup(string coverageGroupName)
        {
            Models.CoverageGroup coverageGroup = GetCoverageGroup(coverageGroupName);
            if (coverageGroup == null)
            {
                return false;
            }

            workingTestSpecification.CoverageGroups.Remove(coverageGroup);
            workingTestSpecification.SpecificationDependencies.DeleteCoverageGroupReferences(
                coverageGroupName);
            return true;
        }

        /// <summary>
        /// Deletes an input parameter in the coverage group from the specification and returns true if successful.
        /// If the parameter is the only one in the group, it deletes the group altogether.
        /// </summary>
        public bool DeleteCoverageGroupInputParameter(string coverageGroupName, string inputParameterName)
        {
            Models.CoverageGroup coverageGroup = GetCoverageGroup(coverageGroupName);
            if (coverageGroup == null)
            {
                return false;
            }

            if ((coverageGroup.Parameters.Count == 1) && coverageGroup.Parameters.Contains(inputParameterName))
            {
                return DeleteCoverageGroup(coverageGroupName);
            }

            coverageGroup.Parameters.Remove(inputParameterName);
            workingTestSpecification.SpecificationDependencies.NewCoverageGroupReferences(
                coverageGroupName, coverageGroup.Parameters);
            return true;
        }

        /// <summary>
        /// Deletes the expected result from the specification and returns true if successful.
        /// </summary>
        public bool DeleteExpectedResult(string expectedResultName)
        {
            Models.ExpectedResult expectedResult = GetExpectedResult(expectedResultName);
            if (expectedResult == null)
            {
                return false;
            }

            workingTestSpecification.ExpectedResults.Remove(expectedResultName);
            workingTestSpecification.SpecificationDependencies.DeleteExpectedResultReferences(expectedResultName);
            return true;
        }

        /// <summary>
        /// Returns the current written form of the generated test case.
        /// </summary>
        public string GetTestCaseAsString(string testCaseName)
        {
            if ((workingTestGenerator == null) ||
                (workingTestGenerator.GeneratedTestsInSuite == null) ||
                (workingTestGenerator.GeneratedTestsInSuite.TestCases == null))
            {
                return string.Empty;
            }

            IList<Models.TestCase> matching = workingTestGenerator.GeneratedTestsInSuite.TestCases
                .Where(x => x.Name == testCaseName).ToList();
            if ((matching == null) || !matching.Any())
            {
                return string.Empty;
            }

            return matching[0].WrittenForm;
        }

        /// <summary>
        /// Returns the current written form of the generated suite of test cases.
        /// </summary>
        public string GetTestScriptAsString(bool populatedAndWritten)
        {
            if (!populatedAndWritten ||
                (workingTestGenerator == null) ||
                (workingTestGenerator.GeneratedTestsInSuite == null) ||
                (workingTestGenerator.GeneratedTestsInSuite.WrittenForm == null))
            {
                return string.Empty;
            }

            return workingTestGenerator.GeneratedTestsInSuite.WrittenForm;
        }

        /// <summary>
        /// Returns the current written form of the generated suite of test cases.
        /// </summary>
        public string GetTestStatisticstAsString(bool populatedAndWritten)
        {
            if (!populatedAndWritten ||
                (workingTestGenerator == null) ||
                (workingTestGenerator.CoverageMetricsInSuite == null) ||
                (workingTestGenerator.CoverageMetricsInSuite.WrittenForm == null))
            {
                return string.Empty;
            }

            return workingTestGenerator.CoverageMetricsInSuite.WrittenForm;
        }

        /// <summary>
        /// Generates test cases in a test suite, yielding data in the working test generator).
        /// Returns true if all test cases are generated correctly.
        /// </summary>
        public bool GenerateTestSuite(out string testSuiteStatus)
        {
            workingTestGenerator = new Models.TestGenerator();
            bool populated = workingTestGenerator.PopulateTestSuite(workingTestSpecification, out testSuiteStatus);
            bool written = workingTestGenerator.WriteAsString(workingTestSpecification.Given);
            return populated && written;
        }
    }
}