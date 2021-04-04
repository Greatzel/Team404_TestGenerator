using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
using System.Linq;
using System.Text;
=======
using System.Linq;
>>>>>>> Merge-Greatzel
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    public class CoverageMetrics
    {
<<<<<<< HEAD
        /// <summary>
        /// The written form of the entire test suite.
        /// </summary>
        public string WrittenForm { get; set; }

        /// <summary>
        /// Mapping that records whether combinations in coverage groups are "covered" by test cases.
        /// </summary>
        private readonly IDictionary<string, IDictionary<string, int>> _recordedCoverages;

        /// <summary>
        /// Constructs and initializes an instance object of the class CoverageMetrics.
        /// </summary>
        public CoverageMetrics()
        {
            WrittenForm = null;

            _recordedCoverages = new Dictionary<string, IDictionary<string, int>>();
        }

        /// <summary>
        /// For all coverage groups, creates an initial coverage matrix that is empty.
        /// Returns true if successful.
        /// </summary>
        public bool Initialize(IList<CoverageGroup> coverageGroups, IDictionary<string, InputParameter> inputParameters)
        {
            foreach (CoverageGroup coverageGroup in coverageGroups)
            {
                IList<string> coverageKeys = GenerateCombinations(string.Empty, 0, coverageGroup.Parameters, inputParameters);
                IDictionary<string, int> recordedCoverage = new Dictionary<string, int>();
                foreach (string coverageKey in coverageKeys)
                {
                    recordedCoverage.Add(coverageKey, 0);
                }

                _recordedCoverages.Add(coverageGroup.Name, recordedCoverage);
            }

            return true;
        }

        /// <summary>
        /// For all coverage groups, records the coverage achieved in a single test case.
        /// Returns true if successful.
        /// </summary>
        public bool Record(IList<CoverageGroup> coverageGroups, TestCase testCase)
        {
            foreach (CoverageGroup coverageGroup in coverageGroups)
            {
                string coverageKey = string.Empty;
                foreach (string parameterName in coverageGroup.Parameters)
                {
                    string equivalenceClass = testCase.ParameterAssignments[parameterName].SelectedEquivalenceClassName();
                    coverageKey = string.IsNullOrEmpty(coverageKey) ? equivalenceClass : $"{coverageKey}.{equivalenceClass}";
                }

                if (!_recordedCoverages[coverageGroup.Name].ContainsKey(coverageKey))
                {
                    _recordedCoverages[coverageGroup.Name].Add(coverageKey, 0);
                }

                _recordedCoverages[coverageGroup.Name][coverageKey]++;
            }

            return true;
        }

        /// <summary>
        /// Returns the key of the coverage group's first uncovered combination. Returns NULL if there is none.
        /// </summary>
        public string FirstUncovered(string coverageGroupName)
        {
            IDictionary<string, int> recordedCoverage = _recordedCoverages[coverageGroupName];
            foreach (string coverageKey in recordedCoverage.Keys.Where(x => recordedCoverage[x] == 0))
            {
                return coverageKey;
            }

            return null;
        }

        /// <summary>
        /// Returns true if all combinations of the given coverage group have been used
        /// in at least one test case.
        /// </summary>
        public bool CoverageComplete(string coverageGroupName)
        {
            IDictionary<string, int> recordedCoverage = _recordedCoverages[coverageGroupName];
            IEnumerable<string> notCovered = recordedCoverage.Keys.Where(x => recordedCoverage[x] == 0);
            return (notCovered == null) || !notCovered.Any();
        }

        /// <summary>
        /// Returns the list of coverage groups, SORTED by number of combinations DESCENDING.
        /// </summary>
        public IList<CoverageGroup> SortedCoverageGroups(TestSpecification testSpecification)
        {
            IDictionary<int, IList<CoverageGroup>> combinationMappings = CombinationMappings(testSpecification);
            List<int> combinationKeys = combinationMappings.Keys.ToList();
            combinationKeys.Sort();
            combinationKeys.Reverse();

            IList<CoverageGroup> sortedCoverageGroups = new List<CoverageGroup>();
            foreach (int combinationKey in combinationKeys)
            {
                foreach (CoverageGroup coverageGroup in combinationMappings[combinationKey])
                {
                    sortedCoverageGroups.Add(coverageGroup);
                }
            }

            return sortedCoverageGroups;
        }

        /// <summary>
        /// Writes the coverage metrics to a string and returns true if successful.
        /// </summary>
        public bool WriteAsString()
        {
            System.Text.StringBuilder writtenForm = new StringBuilder();

            writtenForm.AppendLine();
            writtenForm.AppendLine($"Coverage metrics:");
            writtenForm.AppendLine();

            int groupsCovered = 0;
            foreach (string coverageGroup in _recordedCoverages.Keys)
            {
                writtenForm.AppendLine($"Number of tests generated to cover combinations of {coverageGroup} = {_recordedCoverages[coverageGroup].Count}");
                IDictionary<string, int> combinations = _recordedCoverages[coverageGroup];

                int combinationsCovered = 0;
                foreach (string combination in combinations.Keys)
                {
                    combinationsCovered = combinations[combination] > 0 ? combinationsCovered + 1 : combinationsCovered;
                }

                bool allCombinationsCovered = combinationsCovered == combinations.Keys.Count;
                groupsCovered = allCombinationsCovered ? groupsCovered + 1 : groupsCovered;

                string combinationsQualifier = allCombinationsCovered ? "All" : $"{combinationsCovered} of {combinations.Keys.Count}";
                writtenForm.AppendLine($"{combinationsQualifier} combinations in {coverageGroup} are used in tests");
                writtenForm.AppendLine();
            }

            bool allGroupsCovered = groupsCovered == _recordedCoverages.Keys.Count;
            string groupsQualifier = allGroupsCovered ? "All" : $"{groupsCovered} of {_recordedCoverages.Keys.Count}";
            writtenForm.AppendLine($"{groupsQualifier} coverage groups are used in tests");

            WrittenForm = writtenForm.ToString();
            return true;
        }

        /// <summary>
        /// Writes the generated coverage metrics to an output file and returns true if successful.
        /// </summary>
        public bool WriteToFile(string filenameWithPath)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(filenameWithPath))
            {
                writer.WriteLine(WrittenForm);
            }

            return true;
        }

        /// <summary>
        /// Generates and returns coverage keys for the current parameter and all subsequent parameters.
        /// </summary>
        private IList<string> GenerateCombinations(
            string prefix, int currentParameter, IList<string> parameters, IDictionary<string, InputParameter> inputParameters)
        {
            IList<string> coverageKeys = new List<string>();
            if (currentParameter >= parameters.Count)
            {
                coverageKeys.Add(prefix);
                return coverageKeys;
            }

            foreach (string equivalenceClassName in inputParameters[parameters[currentParameter]].EquivalenceClasses.Keys)
            {
                int nextParameter = currentParameter + 1;
                string nextPrefix = string.IsNullOrEmpty(prefix) ? equivalenceClassName : $"{prefix}.{equivalenceClassName}";
                IList<string> nextCoverageKeys = GenerateCombinations(nextPrefix, nextParameter, parameters, inputParameters);
                foreach (string nextCoverageKey in nextCoverageKeys)
                {
                    coverageKeys.Add(nextCoverageKey);
                }
            }

            return coverageKeys;
        }

        /// <summary>
        /// Returns a dictionary mapping a number of combinations onto the list of 1 or more coverage
        /// groups whose parameters have that specific number of exhaustive combinations.
        /// 
        /// For example, if coverage group has parameters (A, B) and A has 3 equivalence classes and B
        /// has 4 equivalence classes, then a mapping is made from 12 onto a list that includes this coverage
        /// group.
        /// </summary>
        private IDictionary<int, IList<CoverageGroup>> CombinationMappings(TestSpecification testSpecification)
        {
            IDictionary<int, IList<CoverageGroup>> combinationMappings = new Dictionary<int, IList<CoverageGroup>>();
            foreach (CoverageGroup coverageGroup in testSpecification.CoverageGroups)
            {
                int combinations = 1;
                foreach (string parameterName in coverageGroup.Parameters)
                {
                    combinations *= testSpecification.InputParameters[parameterName].EquivalenceClasses.Count;
                }

                if (!combinationMappings.ContainsKey(combinations))
                {
                    combinationMappings.Add(combinations, new List<CoverageGroup>());
                }

                combinationMappings[combinations].Add(coverageGroup);
            }

            return combinationMappings;
        }
=======
>>>>>>> Merge-Greatzel
    }
}