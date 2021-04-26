using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using GGC.TestCaseGenerator.Models;
using GGC.TestCaseGenerator.Helpers;

namespace GGC.TestCaseGenerator.Tests
{
    public class GeneratorTests
    {
        /*/// <summary>
        /// Given that I have an input file in XML format that defines a test specification,
        /// when I generate a test suite of 1 or more test cases from the specification,
        /// then that test suite is written as an output file.
        /// </summary>
        [TestCase("MultiTenantOnboardingSecurity.xml", "Tests_MultiTenantOnboardingSecurity.txt")]
        [TestCase("MultiTenantRecruitingSecurity.xml", "Tests_MultiTenantRecruitingSecurity.txt")]
        [TestCase("MultiTenantUltiproSecurity.xml", "Tests_MultiTenantUltiproSecurity.txt")]
        [TestCase("IcmVerboseLogging_Tenants.xml", "Tests_IcmVerboseLogging_Tenants.txt")]
        [TestCase("IcmVerboseLogging_Expiration.xml", "Tests_IcmVerboseLogging_Expiration.txt")]
        [TestCase("MdrFilterByDateRange.xml", "Tests_MdrFilterByDateRange.txt")]
        [TestCase("ExecutionQueueOnSave.xml", "Tests_ExecutionQueueOnSave.txt")]
        [TestCase("QuadraticEquationSolver.xml", "Tests_QuadraticEquationSolver.txt")]
        [TestCase("QuadraticEquationSolverAttributes.xml", "Tests_QuadraticEquationSolverAttributes.txt")]
        [TestCase("ExhaustiveQuadraticEquationSolver.xml", "Tests_ExhaustiveQuadraticEquationSolver.txt")]
        [TestCase("ExpressionsExampleWithRecursion.xml", "Tests_ExpressionsExampleWithRecursion.txt")]
        [TestCase("StatusMessages249854.xml", "Tests_StatusMessages249854.txt")]
        [TestCase("StatusMessages249896.xml", "Tests_StatusMessages249896.txt")]
        [TestCase("StatusMessages249897.xml", "Tests_StatusMessages249897.txt")]
        [TestCase("OrgLevelUnits.xml", "Tests_OrgLevelUnits.txt")]
        public void ProcessingXmlTestSpecificationYieldsTestScript(string inputFilename, string outputFilename)
        {
            string inputFilenameWithPath = $"{FileHelper.PathTestGenerator}\\{inputFilename}";
            string outputFilenameWithPath = $"{FileHelper.PathTestGenerator}\\{outputFilename}";

            TestGenerator testGenerator = new TestGenerator();
            Assert.True(
                testGenerator.CreateSuiteFromSpecificationAndWrite(inputFilenameWithPath, outputFilenameWithPath),
                $"Failed to create test suite from test specification in {inputFilename} and write it to {outputFilename}");
        }
        */
        /// <summary>
        /// Given that I have an input file in JSON format that defines a test specification,
        /// when I generate a test suite of 1 or more test cases from the specification,
        /// then that test suite is written as an output file.
        /// </summary>
        [TestCase("CoverageExample_None.json", "FromJson_CoverageExample_None.txt")]
        [TestCase("CoverageExample_Pairwise.json", "FromJson_CoverageExample_Pairwise.txt")]
        [TestCase("CoverageExample_Exhaustive.json", "FromJson_CoverageExample_Exhaustive.txt")]
        [TestCase("CoverageExample_Conditional.json", "FromJson_CoverageExample_Conditional.txt")]
        [TestCase("CoverageExample_Targeted.json", "FromJson_CoverageExample_Targeted.txt")]
        [TestCase("CoverageExample_BetterResults.json", "FromJson_CoverageExample_BetterResults.txt")]
        [TestCase("MultiTenantOnboardingSecurity.json", "FromJson_MultiTenantOnboardingSecurity.txt")]
        [TestCase("MultiTenantRecruitingSecurity.json", "FromJson_MultiTenantRecruitingSecurity.txt")]
        [TestCase("MultiTenantUltiproSecurity.json", "FromJson_MultiTenantUltiproSecurity.txt")]
        [TestCase("IcmVerboseLogging_Tenants.json", "FromJson_IcmVerboseLogging_Tenants.txt")]
        [TestCase("IcmVerboseLogging_Expiration.json", "FromJson_IcmVerboseLogging_Expiration.txt")]
        [TestCase("MdrFilterByDateRange.json", "FromJson_MdrFilterByDateRange.txt")]
        [TestCase("ExecutionQueueOnSave.json", "FromJson_ExecutionQueueOnSave.txt")]
        [TestCase("ExecutionQueueOnSaveString.json", "FromJson_ExecutionQueueOnSaveString.txt")]
        [TestCase("QuadraticEquationSolver.json", "FromJson_QuadraticEquationSolver.txt")]
        [TestCase("QuadraticEquationSolverAttributes.json", "FromJson_QuadraticEquationSolverAttributes.txt")]
        [TestCase("ExhaustiveQuadraticEquationSolver.json", "FromJson_ExhaustiveQuadraticEquationSolver.txt")]
        [TestCase("ExpressionsExampleWithRecursion.json", "FromJson_ExpressionsExampleWithRecursion.txt")]
        [TestCase("StatusMessages249854.json", "FromJson_StatusMessages249854.txt")]
        [TestCase("StatusMessages249896.json", "FromJson_StatusMessages249896.txt")]
        [TestCase("StatusMessages249897.json", "FromJson_StatusMessages249897.txt")]
        [TestCase("OrgLevelUnits.json", "FromJson_OrgLevelUnits.txt")]
        public void ProcessingJsonTestSpecificationYieldsTestScript(string inputFilename, string outputFilename)
        {
            string inputFilenameWithPath = $"{FileHelper.PathTestGenerator}\\{inputFilename}";
            string outputFilenameWithPath = $"{FileHelper.PathTestGenerator}\\{outputFilename}";

            TestGenerator testGenerator = new TestGenerator();
            Assert.True(
                testGenerator.CreateSuiteFromSpecificationAndWrite(inputFilenameWithPath, outputFilenameWithPath),
                $"Failed to create test suite from test specification in {inputFilename} and write it to {outputFilename}");
        }
    }
}