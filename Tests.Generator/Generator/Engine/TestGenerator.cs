//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  05/24/2017
//// Reason:
////     ULTI-249839: Write a tool to generate test cases from an XML specification.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generator.Engine
{
    /// <summary>
    /// Class that generates test cases from a test specification and writes the resulting
    /// test suite to an output file.
    /// </summary>
    public class TestGenerator
    {
        public enum FormatEnum
        {
            None,
            Json,
            Text,
            Xml
        };

        /// <summary>
        /// The name of the XML input file including its full path.
        /// </summary>
        public string InputFilenameWithPath { get; set; }

        /// <summary>
        /// The name of the output input file including its full path.
        /// </summary>
        public string OutputFilenameWithPath { get; set; }

        /// <summary>
        /// Class that encapsulates a test suite of test cases.
        /// </summary>
        public TestSuite GeneratedTestsInSuite { get; set; }

        /// <summary>
        /// Class that encapsulates how coverage metrics are determined.
        /// </summary>
        public CoverageMetrics CoverageMetricsInSuite { get; set; }

        /// <summary>
        /// Unique number for each generated test case.
        /// </summary>
        private int _testCaseNumber;

        /// <summary>
        /// Random number generator used when selecting parameters' equivalence
        /// classes randomly.
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Format of the input file (as defined by its extension).
        /// </summary>
        private FormatEnum _inputFormat;

        /// <summary>
        /// Constructs and initializes an instance object of the class TestGenerator.
        /// </summary>
        public TestGenerator()
        {
            InputFilenameWithPath = null;
            OutputFilenameWithPath = null;
            GeneratedTestsInSuite = null;
            CoverageMetricsInSuite = new CoverageMetrics();

            _testCaseNumber = 0;
            _random = new Random();
            _inputFormat = FormatEnum.None;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(string inputFilenameWithPath, string outputFilenameWithPath)
        {
            InputFilenameWithPath = inputFilenameWithPath;
            OutputFilenameWithPath = outputFilenameWithPath;

            _inputFormat = ImplicitFormat(inputFilenameWithPath);
            return true;
        }

        /// <summary>
        /// Reads the test specification from an XML input file, generates a test suite
        /// from that test specification, and writes the test suite to an output file.
        /// Returns true if successful.
        /// </summary>
        public bool CreateSuiteFromSpecificationAndWrite(string inputFilenameWithPath, string outputFilenameWithPath)
        {
            if (!Set(inputFilenameWithPath, outputFilenameWithPath))
            {
                return false;
            }

            TestSpecification testSpecification = Read(InputFilenameWithPath, _inputFormat);
            if (testSpecification == null)
            {
                return false;
            }

            string testSuiteStatus;
            GeneratedTestsInSuite = new TestSuite();
            GeneratedTestsInSuite.Set(testSpecification.Name, testSpecification.Text, new List<TestCase>());
            if (!PopulateTestSuite(testSpecification, out testSuiteStatus))
            {
                return false;
            }

            return WriteToFile(OutputFilenameWithPath, testSpecification.Given);
        }

        /// <summary>
        /// Generates a test suite of test cases based on the test specification.
        /// Returns true if successful.
        /// </summary>
        public bool PopulateTestSuite(TestSpecification testSpecification, out string testSuiteStatus)
        {
            int numberConsistent = 0;
            GeneratedTestsInSuite = new TestSuite();
            GeneratedTestsInSuite.Set(testSpecification.Name, testSpecification.Text, new List<TestCase>());

            CoverageMetricsInSuite.Initialize(testSpecification.CoverageGroups, testSpecification.InputParameters);
            foreach (CoverageGroup coverageGroup in CoverageMetricsInSuite.SortedCoverageGroups(testSpecification))
            {
                while (!CoverageMetricsInSuite.CoverageComplete(coverageGroup.Name))
                {
                    TestCase testCase = PopulateTestCase(testSpecification, coverageGroup);
                    if (testCase == null)
                    {
                        testSuiteStatus =
                            $"Aborted after generating {GeneratedTestsInSuite.TestCases.Count} test cases for test specification {testSpecification.Name}";
                        return false;
                    }

                    CoverageMetricsInSuite.Record(testSpecification.CoverageGroups, testCase);
                    GeneratedTestsInSuite.TestCases.Add(testCase);
                    numberConsistent += testCase.Valuation ? 1 : 0;
                }
            }

            int numberContradictory = GeneratedTestsInSuite.TestCases.Count - numberConsistent;
            testSuiteStatus = $"Generated {GeneratedTestsInSuite.TestCases.Count} test cases for test specification {testSpecification.Name} ({numberConsistent} consistent, {numberContradictory} contradictory)";
            return true;
        }

        /// <summary>
        /// Writes the generated test suite and coverage metrics to an output file and returns true if successful.
        /// </summary>
        public bool WriteToFile(string filenameWithPath, string specificationGiven)
        {
            if (WriteAsString(specificationGiven))
            {
                using (StreamWriter writer = new StreamWriter(filenameWithPath))
                {
                    writer.WriteLine(GeneratedTestsInSuite.WrittenForm);
                    writer.WriteLine(CoverageMetricsInSuite.WrittenForm);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Writes the generated test suite and coverage metrics to strings and returns true if successful.
        /// </summary>
        public bool WriteAsString(string specificationGiven)
        {
            bool compositeWrite = GeneratedTestsInSuite.WriteAsString(specificationGiven);
            compositeWrite = CoverageMetricsInSuite.WriteAsString() && compositeWrite;
            return compositeWrite
                   && !string.IsNullOrEmpty(GeneratedTestsInSuite.WrittenForm)
                   && !string.IsNullOrEmpty(CoverageMetricsInSuite.WrittenForm);
        }

        /// <summary>
        /// Reads the test specification in its given format and returns the resulting object.
        /// </summary>
        private TestSpecification Read(string inputFilenameWithPath, FormatEnum inputFormat)
        {
            TestSpecification testSpecification = new TestSpecification();
            if (((inputFormat == FormatEnum.Xml) && testSpecification.ReadAsXml(inputFilenameWithPath)) ||
                ((inputFormat == FormatEnum.Json) && testSpecification.ReadAsJson(inputFilenameWithPath)))
            {
                return testSpecification;
            }

            return null;
        }

        /// <summary>
        /// Generates a single test case that selects an "uncovered" combination from the coverage group.
        /// Returns the test case if successful, otherwise null.
        /// </summary>
        private TestCase PopulateTestCase(TestSpecification testSpecification, CoverageGroup coverageGroup)
        {
            IList<string> uncoveredCombination = CoverageMetricsInSuite.FirstUncovered(coverageGroup.Name)
                .Split(new char[] { '.' }, StringSplitOptions.None);

            IDictionary<string, ParameterAssignment> parameterAssignments = new Dictionary<string, ParameterAssignment>();
            for (int groupIndex = 0; groupIndex < coverageGroup.Parameters.Count; groupIndex++)
            {
                if (!AssignCoveredParameter(parameterAssignments, testSpecification, coverageGroup, uncoveredCombination, groupIndex))
                {
                    return null;
                }
            }

            foreach (InputParameter inputParameter in testSpecification.InputParameters.Values
                .Where(x => !coverageGroup.Parameters.Contains(x.Name)))
            {
                if (!AssignUncoveredParameter(parameterAssignments, inputParameter))
                {
                    return null;
                }
            }

            bool valuation = true;
            foreach (ParameterAssignment parameterAssignment in parameterAssignments.Values)
            {
                valuation = valuation &&
                            AssociatedParameterValuation(parameterAssignments,
                                testSpecification.InputParameters[parameterAssignment.Name]) &&
                            AssociatedEquivalenceClassValuation(parameterAssignments,
                                parameterAssignment.SelectedEquivalenceClass);
            }

            IList<ExpectedResult> expectedResults = new List<ExpectedResult>();
            foreach (ExpectedResult expectedResult in testSpecification.ExpectedResults.Values
                .Where(x => x.ConditionExpression.Match(parameterAssignments)))
            {
                expectedResults.Add(expectedResult);
            }

            valuation = (expectedResults.Count == 0) ? false : valuation;

            _testCaseNumber++;
            string given = testSpecification.Given;
            string name = $"{testSpecification.Name}-{_testCaseNumber}";
            string text = $"Test {_testCaseNumber}";

            TestCase testCase = new TestCase();
            testCase.Set(given, name, text, parameterAssignments, expectedResults, valuation);
            return testCase;
        }

        /// <summary>
        /// Creates and returns an assignment for a parameter in the coverage group
        /// based on a specific combination that has not yet been covered in a test case.
        /// </summary>
        private bool AssignCoveredParameter(
            IDictionary<string, ParameterAssignment> parameterAssignments,
            TestSpecification testSpecification,
            CoverageGroup coverageGroup,
            IList<string> uncoveredCombination,
            int groupIndex)
        {
            string selectedParameter = coverageGroup.Parameters[groupIndex];
            string selectedEquivalenceClass = uncoveredCombination[groupIndex];
            if ((selectedParameter == null) || (selectedEquivalenceClass == null))
            {
                return false;
            }

            InputParameter inputParameter = testSpecification.InputParameters[selectedParameter];
            if (inputParameter == null)
            {
                return false;
            }

            ParameterAssignment parameterAssignment = new ParameterAssignment();
            parameterAssignment.Set(
                inputParameter.Given,
                inputParameter.Name,
                inputParameter.Text,
                inputParameter.EquivalenceClasses[selectedEquivalenceClass]);

            parameterAssignments.Add(parameterAssignment.Name, parameterAssignment);
            return true;
        }

        /// <summary>
        /// Creates and returns an assignment for a parameter that is NOT in the coverage group
        /// by randomly selecting one of its equivalence classes.
        /// </summary>
        private bool AssignUncoveredParameter(
            IDictionary<string, ParameterAssignment> parameterAssignments,
            InputParameter inputParameter)
        {
            IList<string> equivalenceClassNames = inputParameter.EquivalenceClasses.Keys.ToList();
            if ((equivalenceClassNames == null) || !equivalenceClassNames.Any())
            {
                return false;
            }

            int randomIndex = _random.Next(equivalenceClassNames.Count);
            string selectedEquivalenceClass = equivalenceClassNames[randomIndex];
            if (string.IsNullOrEmpty(selectedEquivalenceClass))
            {
                return false;
            }

            ParameterAssignment parameterAssignment = new ParameterAssignment();
            parameterAssignment.Set(
                inputParameter.Given,
                inputParameter.Name,
                inputParameter.Text,
                inputParameter.EquivalenceClasses[selectedEquivalenceClass]);

            parameterAssignments.Add(parameterAssignment.Name, parameterAssignment);
            return true;
        }

        /// <summary>
        /// Evaluates the constraints of a selected parameter, if any, and returns true
        /// or false based on the evaluation.
        /// </summary>
        private bool AssociatedParameterValuation(
            IDictionary<string, ParameterAssignment> parameterAssignments,
            InputParameter inputParameter)
        {
            if ((inputParameter != null) &&
                (inputParameter.ConditionExpression != null) &&
                !inputParameter.ConditionExpression.Match(parameterAssignments))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Evaluates the constraints of a selected equivalence class, if any, and returns true
        /// or false based on the evaluation.
        /// </summary>
        private bool AssociatedEquivalenceClassValuation(
            IDictionary<string, ParameterAssignment> parameterAssignments,
            EquivalenceClass equivalenceClass)
        {
            if ((equivalenceClass != null) &&
                (equivalenceClass.ConditionExpression != null) &&
                !equivalenceClass.ConditionExpression.Match(parameterAssignments))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the format of the input file as defined by its extension.
        /// </summary>
        private FormatEnum ImplicitFormat(string inputFilenameWithPath)
        {
            if (inputFilenameWithPath.Contains(".json"))
            {
                return FormatEnum.Json;
            }

            if (inputFilenameWithPath.Contains(".txt"))
            {
                return FormatEnum.Text;
            }

            if (inputFilenameWithPath.Contains(".xml"))
            {
                return FormatEnum.Xml;
            }

            return FormatEnum.None;
        }
    }
}
