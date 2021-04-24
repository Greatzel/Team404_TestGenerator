using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace GGC.TestCaseGenerator.Models
{
    /// <summary>
    /// Class that encapsulates a test suite of 1 or more test cases yielded
    /// by generating tests from the test specification.
    /// </summary>
    public class TestSuite
    {
        /// <summary>
        /// The name of the test suite (same as test specification).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the test suite (same as test specification).
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ordered list of test cases belonging to the test suite.
        /// </summary>
        public IList<TestCase> TestCases { get; set; }

        /// <summary>
        /// The written form of the entire test suite.
        /// </summary>
        public string WrittenForm { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class TestSuite.
        /// </summary>
        public TestSuite()
        {
            Name = null;
            Text = null;
            TestCases = null;
            WrittenForm = null;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(string name, string text, IList<TestCase> testCases)
        {
            Name = name;
            Text = text;
            TestCases = testCases;
            return true;
        }

        /// <summary>
        /// Writes the generated test suite as a string and returns true if successful.
        /// </summary>
        public bool WriteAsString(string specificationGiven)
        {
            bool compositeWrite = true;
            System.Text.StringBuilder writtenForm = new StringBuilder();
            writtenForm.AppendLine($"Test suite {Name} : {Text}");

            IList<TestCase> consistentTestCases = TestCases.Where(x => x.Valuation).ToList();
            if (consistentTestCases.Any())
            {
                writtenForm.AppendLine($"Number of generated test cases included : {consistentTestCases.Count}");
                foreach (TestCase testCase in consistentTestCases)
                {
                    if (!testCase.WriteAsString(specificationGiven))
                    {
                        compositeWrite = false;
                        continue;
                    }

                    writtenForm.AppendLine(testCase.WrittenForm);
                }
            }

            IList<TestCase> contradictoryTestCases = TestCases.Where(x => !x.Valuation).ToList();
            if (contradictoryTestCases.Any())
            {
                writtenForm.AppendLine();
                writtenForm.AppendLine($"Number of contradictory test cases excluded : {contradictoryTestCases.Count}");
            }

            WrittenForm = writtenForm.ToString();
            return compositeWrite;
        }

        /// <summary>
        /// Writes the generated test suite to an output file and returns true if successful.
        /// </summary>
        public bool WriteToFile(string filenameWithPath)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(filenameWithPath))
            {
                writer.WriteLine(WrittenForm);
            }

            return true;
        }
    }
}