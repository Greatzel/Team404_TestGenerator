using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
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
    }
}