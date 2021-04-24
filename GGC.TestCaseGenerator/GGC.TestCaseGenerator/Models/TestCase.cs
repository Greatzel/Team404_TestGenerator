using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace GGC.TestCaseGenerator.Models
{
    /// <summary>
    /// Class that encapsulates one test case yielded by generating tests from the test specification.
    /// </summary>
    public class TestCase
    {
        /// <summary>
        /// The name of the test case (automatically generated).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the test case (automatically generated from parameters
        /// and expected results, i.e. "WHEN ... THEN ...").
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ordered list of parameter assignments used in this test case.
        /// </summary>
        public IDictionary<string, ParameterAssignment> ParameterAssignments { get; set; }

        /// <summary>
        /// Ordered list of expected results for this test case.
        /// </summary>
        public IList<ExpectedResult> ExpectedResults { get; set; }

        /// <summary>
        /// True if the constraints associated with the parameters and equivalence classes of the
        /// test case evaluate to true.
        /// </summary>
        public bool Valuation { get; set; }

        /// <summary>
        /// The written form of the entire test suite.
        /// </summary>
        public string WrittenForm { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class TestCase.
        /// </summary>
        public TestCase()
        {
            Name = null;
            Text = null;
            ParameterAssignments = null;
            ExpectedResults = null;
            Valuation = true;
            WrittenForm = null;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(
            string given,
            string name,
            string text,
            IDictionary<string, ParameterAssignment> parameterAssignments,
            IList<ExpectedResult> expectedResults,
            bool valuation)
        {
            Name = name;
            Text = text;
            ParameterAssignments = parameterAssignments;
            ExpectedResults = expectedResults;
            Valuation = valuation;
            return true;
        }

        /// <summary>
        /// Writes the generated test case as a string and returns true if successful.
        /// </summary>
        public bool WriteAsString(string specificationGiven)
        {
            StringBuilder writtenForm = new StringBuilder();

            writtenForm.AppendLine();
            writtenForm.AppendLine($"----------------------------------------------------------------");
            writtenForm.AppendLine($"Test case {Name} : {Text}");

            bool firstPhrase = true;
            IList<string> compositeGiven = CompositeGiven(specificationGiven);
            if (compositeGiven.Any())
            {
                writtenForm.Append($"Given ");
                foreach (string given in compositeGiven)
                {
                    firstPhrase = ConditionalWriteAnd(writtenForm, firstPhrase);
                    writtenForm.Append(given);
                }
            }

            firstPhrase = true;
            writtenForm.AppendLine();
            writtenForm.Append($"When ");
            foreach (ParameterAssignment parameterAssignment in ParameterAssignments.Values)
            {
                firstPhrase = ConditionalWriteAnd(writtenForm, firstPhrase);
                writtenForm.Append(parameterAssignment.WriteAsString());
            }

            firstPhrase = true;
            writtenForm.AppendLine();
            writtenForm.Append($"Then ");
            foreach (ExpectedResult expectedResult in ExpectedResults)
            {
                firstPhrase = ConditionalWriteAnd(writtenForm, firstPhrase);
                writtenForm.Append(expectedResult.WriteAsString());
            }

            writtenForm.AppendLine();
            WrittenForm = writtenForm.ToString();
            return true;
        }

        /// <summary>
        /// Conditionally writes an AND into a statement.
        /// </summary>
        private bool ConditionalWriteAnd(StringBuilder writtenForm, bool firstPhrase)
        {
            if (!firstPhrase)
            {
                writtenForm.AppendLine();
                writtenForm.Append($"    and ");
            }

            // After writing the AND, it's no longer the first phrase (hence false).
            return false;
        }

        /// <summary>
        /// Collects all of the GIVEN clauses for the contents of the specific test case,
        /// i.e. parameter assignments and expected results.
        /// </summary>
        private IList<string> CompositeGiven(string specificationGiven)
        {
            IList<string> compositeGiven = new List<string>();
            if (!string.IsNullOrEmpty(specificationGiven))
            {
                compositeGiven.Add(specificationGiven);
            }

            foreach (ParameterAssignment parameterAssignment in ParameterAssignments.Values)
            {
                if (!string.IsNullOrEmpty(parameterAssignment.Given))
                {
                    compositeGiven.Add(parameterAssignment.Given);
                }

                if ((parameterAssignment.SelectedEquivalenceClass != null) &&
                    !string.IsNullOrEmpty(parameterAssignment.SelectedEquivalenceClass.Given))
                {
                    compositeGiven.Add(parameterAssignment.SelectedEquivalenceClass.Given);
                }
            }

            foreach (ExpectedResult expectedResult in ExpectedResults)
            {
                if (!string.IsNullOrEmpty(expectedResult.Given))
                {
                    compositeGiven.Add(expectedResult.Given);
                }
            }

            return compositeGiven;
        }
    }
}