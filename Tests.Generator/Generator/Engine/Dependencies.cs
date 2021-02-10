//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  08/09/2018
//// Reason:
////     ULTI-306203: implement a viewer for the Test Case Generator.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Engine
{
    /// <summary>
    /// Class that encapsulates methods and data pertaining to dependencies
    /// between input parameters, equivalence classes, expected results, and coverage
    /// groups.
    /// </summary>
    public class Dependencies
    {
        /// <summary>
        /// Specifies the objects that parameters use.
        /// </summary>
        private readonly IDictionary<string, DependentObjects> _inputParameterDependencies;

        /// <summary>
        /// Specifies the objects that equivalence classes use.
        /// </summary>
        private readonly IDictionary<string, DependentObjects> _equivalenceClassDependencies;

        /// <summary>
        /// Specifies the objects that expected results use.
        /// </summary>
        private readonly IDictionary<string, DependentObjects> _expectedResultDependencies;

        /// <summary>
        /// Specifies the objects that coverage groups use.
        /// </summary>
        private readonly IDictionary<string, DependentObjects> _coverageGroupDependencies;

        /// <summary>
        /// Specifies the objects that parameters use.
        /// </summary>
        private readonly IDictionary<string, ConsumerObjects> _inputParameterConsumers;

        /// <summary>
        /// Specifies the objects that parameters use.
        /// </summary>
        private readonly IDictionary<string, ConsumerObjects> _equivalenceClassConsumers;

        /// <summary>
        /// Constructs and initializes an instance object of the class CoverageGroup.
        /// </summary>
        public Dependencies()
        {
            _inputParameterDependencies = new Dictionary<string, DependentObjects>();
            _equivalenceClassDependencies = new Dictionary<string, DependentObjects>();
            _expectedResultDependencies = new Dictionary<string, DependentObjects>();
            _coverageGroupDependencies = new Dictionary<string, DependentObjects>();
            _inputParameterConsumers = new Dictionary<string, ConsumerObjects>();
            _equivalenceClassConsumers = new Dictionary<string, ConsumerObjects>();
        }

        /// <summary>
        /// Returns true if the given parameter is consumed by other objects, along with
        /// a message detailing its uses (otherwise returns false and a null string).
        /// </summary>
        public bool InputParameterIsConsumed(string parameter, out string consumers)
        {
            consumers = null;
            ConsumerObjects consumerObjects =
                ((_inputParameterConsumers == null) ||
                 !_inputParameterConsumers.ContainsKey(parameter))
                    ? null
                    : _inputParameterConsumers[parameter];

            if (consumerObjects == null)
            {
                return false;
            }

            string consumerList = consumerObjects.ListOfConsumers();
            if (string.IsNullOrEmpty(consumerList))
            {
                return false;
            }

            consumers = $"Input parameter {parameter} is used by {consumerList}";
            return true;
        }

        /// <summary>
        /// Returns true if the given equivalence class is consumed by other objects, along
        /// with a message detailing its uses (otherwise returns false and a null string).
        /// </summary>
        public bool EquivalenceClassIsConsumed(string parameter, string equivalenceClass, out string consumers)
        {
            consumers = null;
            string qualifiedEquivalenceClass = $"{parameter}.{equivalenceClass}";
            ConsumerObjects consumerObjects =
                ((_equivalenceClassConsumers == null) ||
                 !_equivalenceClassConsumers.ContainsKey(qualifiedEquivalenceClass))
                    ? null
                    : _equivalenceClassConsumers[qualifiedEquivalenceClass];

            if (consumerObjects == null)
            {
                return false;
            }

            string consumerList = consumerObjects.ListOfConsumers();
            if (string.IsNullOrEmpty(consumerList))
            {
                return false;
            }

            consumers = $"Equivalence class {qualifiedEquivalenceClass} is used by {consumerList}";
            return true;
        }

        /// <summary>
        /// Creates new dependencies from parameter X onto the entities referenced in its condition.
        /// </summary>
        public void NewInputParameterReferences(string consumerParameter, Expression condition)
        {
            DeleteInputParameterReferences(consumerParameter);
            if (condition == null)
            {
                return;
            }

            IList<string> parametersAndEquivalenceClasses = ExpressionParametersAndEquivalenceClasses(condition);
            foreach (string parameter in parametersAndEquivalenceClasses.Where(x => !x.Contains(".")))
            {
                AddInputParameterDependenciesAsNeeded(consumerParameter);
                AddInputParameterConsumersAsNeeded(parameter);
                _inputParameterDependencies[consumerParameter].AddInputParameterAsNeeded(parameter);
                _inputParameterConsumers[parameter].AddInputParameterAsNeeded(consumerParameter);
            }

            foreach (string equivalenceClass in parametersAndEquivalenceClasses.Where(x => x.Contains(".")))
            {
                AddInputParameterDependenciesAsNeeded(consumerParameter);
                AddEquivalenceClassConsumersAsNeeded(equivalenceClass);
                _inputParameterDependencies[consumerParameter].AddEquivalenceClassAsNeeded(equivalenceClass);
                _equivalenceClassConsumers[equivalenceClass].AddInputParameterAsNeeded(consumerParameter);
            }
        }

        /// <summary>
        /// Creates new dependencies from equivalence class X onto the entities referenced in its condition.
        /// </summary>
        public void NewEquivalenceClassReferences(string consumerParameter, string consumerEquivalenceClass, Expression condition)
        {
            DeleteEquivalenceClassReferences(consumerParameter, consumerEquivalenceClass);
            if (condition == null)
            {
                return;
            }

            string qualifiedConsumerEquivalenceClass = $"{consumerParameter}.{consumerEquivalenceClass}";
            IList<string> parametersAndEquivalenceClasses = ExpressionParametersAndEquivalenceClasses(condition);
            foreach (string parameter in parametersAndEquivalenceClasses.Where(x => !x.Contains(".")))
            {
                AddEquivalenceClassDependenciesAsNeeded(qualifiedConsumerEquivalenceClass);
                AddInputParameterConsumersAsNeeded(parameter);
                _equivalenceClassDependencies[qualifiedConsumerEquivalenceClass].AddInputParameterAsNeeded(parameter);
                _inputParameterConsumers[parameter].AddEquivalenceClassAsNeeded(qualifiedConsumerEquivalenceClass);
            }

            foreach (string equivalenceClass in parametersAndEquivalenceClasses.Where(x => x.Contains(".")))
            {
                AddEquivalenceClassDependenciesAsNeeded(qualifiedConsumerEquivalenceClass);
                AddEquivalenceClassConsumersAsNeeded(equivalenceClass);
                _equivalenceClassDependencies[qualifiedConsumerEquivalenceClass].AddEquivalenceClassAsNeeded(equivalenceClass);
                _equivalenceClassConsumers[equivalenceClass].AddEquivalenceClassAsNeeded(qualifiedConsumerEquivalenceClass);
            }
        }

        /// <summary>
        /// Creates new dependencies from expected result X onto the entities referenced in its condition.
        /// </summary>
        public void NewExpectedResultReferences(string consumerExpectedResult, Expression condition)
        {
            DeleteExpectedResultReferences(consumerExpectedResult);
            if (condition == null)
            {
                return;
            }

            IList<string> parametersAndEquivalenceClasses = ExpressionParametersAndEquivalenceClasses(condition);
            foreach (string parameter in parametersAndEquivalenceClasses.Where(x => !x.Contains(".")))
            {
                AddExpectedResultDependenciesAsNeeded(consumerExpectedResult);
                AddInputParameterConsumersAsNeeded(parameter);
                _expectedResultDependencies[consumerExpectedResult].AddInputParameterAsNeeded(parameter);
                _inputParameterConsumers[parameter].AddExpectedResultAsNeeded(consumerExpectedResult);
            }

            foreach (string equivalenceClass in parametersAndEquivalenceClasses.Where(x => x.Contains(".")))
            {
                AddExpectedResultDependenciesAsNeeded(consumerExpectedResult);
                AddEquivalenceClassConsumersAsNeeded(equivalenceClass);
                _expectedResultDependencies[consumerExpectedResult].AddEquivalenceClassAsNeeded(equivalenceClass);
                _equivalenceClassConsumers[equivalenceClass].AddExpectedResultAsNeeded(consumerExpectedResult);
            }
        }

        /// <summary>
        /// Creates new dependencies from coverage group X onto the parameters referenced in its group list.
        /// </summary>
        public void NewCoverageGroupReferences(string consumerCoverageGroup, IList<string> parameters)
        {
            DeleteCoverageGroupReferences(consumerCoverageGroup);

            foreach (string parameter in parameters)
            {
                AddCoverageGroupDependenciesAsNeeded(consumerCoverageGroup);
                AddInputParameterConsumersAsNeeded(parameter);
                _coverageGroupDependencies[consumerCoverageGroup].AddInputParameterAsNeeded(parameter);
                _inputParameterConsumers[parameter].AddCoverageGroupAsNeeded(consumerCoverageGroup);
            }
        }

        /// <summary>
        /// Deletes all dependencies "X uses Y" for parameter X.
        /// </summary>
        public void DeleteInputParameterReferences(string parameter)
        {
            if (_inputParameterDependencies.ContainsKey(parameter))
            {
                foreach (string parameterName in _inputParameterDependencies[parameter].InputParameters)
                {
                    _inputParameterConsumers[parameterName].CoverageGroups.Remove(parameter);
                }

                foreach (string equivalenceClassName in _inputParameterDependencies[parameter].EquivalenceClasses)
                {
                    _equivalenceClassConsumers[equivalenceClassName].CoverageGroups.Remove(parameter);
                }

                _inputParameterDependencies.Remove(parameter);
            }
        }

        /// <summary>
        /// Deletes all dependencies "X uses Y" for equivalence class X.
        /// </summary>
        public void DeleteEquivalenceClassReferences(string parameter, string equivalenceClass)
        {
            string qualifiedEquivalenceClass = $"{parameter}.{equivalenceClass}";
            if (_equivalenceClassDependencies.ContainsKey(qualifiedEquivalenceClass))
            {
                foreach (string parameterName in _equivalenceClassDependencies[qualifiedEquivalenceClass].InputParameters)
                {
                    _inputParameterConsumers[parameterName].CoverageGroups.Remove(qualifiedEquivalenceClass);
                }

                foreach (string equivalenceClassName in _equivalenceClassDependencies[qualifiedEquivalenceClass]
                    .EquivalenceClasses)
                {
                    _equivalenceClassConsumers[equivalenceClassName].CoverageGroups.Remove(qualifiedEquivalenceClass);
                }

                _equivalenceClassDependencies.Remove(qualifiedEquivalenceClass);
            }
        }

        /// <summary>
        /// Deletes all dependencies "X uses Y" for expected result X.
        /// </summary>
        public void DeleteExpectedResultReferences(string expectedResult)
        {
            if (_expectedResultDependencies.ContainsKey(expectedResult))
            {
                foreach (string parameterName in _expectedResultDependencies[expectedResult].InputParameters)
                {
                    _inputParameterConsumers[parameterName].CoverageGroups.Remove(expectedResult);
                }

                foreach (string equivalenceClassName in _expectedResultDependencies[expectedResult].EquivalenceClasses)
                {
                    _equivalenceClassConsumers[equivalenceClassName].CoverageGroups.Remove(expectedResult);
                }

                _expectedResultDependencies.Remove(expectedResult);
            }
        }

        /// <summary>
        /// Deletes all dependencies "X uses Y" for coverage group X.
        /// </summary>
        public void DeleteCoverageGroupReferences(string coverageGroup)
        {
            if (_coverageGroupDependencies.ContainsKey(coverageGroup))
            {
                foreach (string parameterName in _coverageGroupDependencies[coverageGroup].InputParameters)
                {
                    _inputParameterConsumers[parameterName].CoverageGroups.Remove(coverageGroup);
                }

                foreach (string equivalenceClassName in _coverageGroupDependencies[coverageGroup].EquivalenceClasses)
                {
                    _equivalenceClassConsumers[equivalenceClassName].CoverageGroups.Remove(coverageGroup);
                }

                _coverageGroupDependencies.Remove(coverageGroup);
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for parameter consumers as needed.
        /// </summary>
        private void AddInputParameterConsumersAsNeeded(string usedParameter)
        {
            if (!_inputParameterConsumers.ContainsKey(usedParameter))
            {
                _inputParameterConsumers.Add(usedParameter, new ConsumerObjects());
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for equivalence class consumers as needed.
        /// </summary>
        private void AddEquivalenceClassConsumersAsNeeded(string usedEquivalenceClass)
        {
            if (!_equivalenceClassConsumers.ContainsKey(usedEquivalenceClass))
            {
                _equivalenceClassConsumers.Add(usedEquivalenceClass, new ConsumerObjects());
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for parameter dependencies as needed.
        /// </summary>
        private void AddInputParameterDependenciesAsNeeded(string parameter)
        {
            if (!_inputParameterDependencies.ContainsKey(parameter))
            {
                _inputParameterDependencies.Add(parameter, new DependentObjects());
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for equivalence class dependencies as needed.
        /// </summary>
        private void AddEquivalenceClassDependenciesAsNeeded(string equivalenceClass)
        {
            if (!_equivalenceClassDependencies.ContainsKey(equivalenceClass))
            {
                _equivalenceClassDependencies.Add(equivalenceClass, new DependentObjects());
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for expected result dependencies as needed.
        /// </summary>
        private void AddExpectedResultDependenciesAsNeeded(string expectedResult)
        {
            if (!_expectedResultDependencies.ContainsKey(expectedResult))
            {
                _expectedResultDependencies.Add(expectedResult, new DependentObjects());
            }
        }

        /// <summary>
        /// Adds a new dictionary mapping for coverage group dependencies as needed.
        /// </summary>
        private void AddCoverageGroupDependenciesAsNeeded(string coverageGroup)
        {
            if (!_coverageGroupDependencies.ContainsKey(coverageGroup))
            {
                _coverageGroupDependencies.Add(coverageGroup, new DependentObjects());
            }
        }

        /// <summary>
        /// Returns the list of parameters and equivalence classes used in an expression.
        /// Equivalence classes are fully qualified with parameter names.
        /// </summary>
        private IList<string> ExpressionParametersAndEquivalenceClasses(Expression condition)
        {
            if (condition == null)
            {
                return null;
            }

            IList<string> references = new List<string>();
            condition.SaveReferences(references);
            return references;
        }
    }

    /// <summary>
    /// Enumerates the list of parameters and equivalence classes that are
    /// used by an object X: when X uses Y,  Y is represented in this object.
    /// </summary>
    public class DependentObjects
    {
        /// <summary>
        /// List of 0 or more parameter names.
        /// </summary>
        public IList<string> InputParameters { get; set; }

        /// <summary>
        /// List of 0 or more equivalence class names, represented as P.E, where
        /// P is the name of a parameter and E is the name of an equivalence class.
        /// </summary>
        public IList<string> EquivalenceClasses { get; set; }

        /// <summary>
        /// Constructs and initializes an instance of class DependentObjects.
        /// </summary>
        public DependentObjects()
        {
            InputParameters = new List<string>();
            EquivalenceClasses = new List<string>();
        }

        public void AddInputParameterAsNeeded(string parameter)
        {
            if (!InputParameters.Contains(parameter))
            {
                InputParameters.Add(parameter);
            }
        }

        public void AddEquivalenceClassAsNeeded(string equivalenceClass)
        {
            if (!EquivalenceClasses.Contains(equivalenceClass))
            {
                EquivalenceClasses.Add(equivalenceClass);
            }
        }
    }

    /// <summary>
    /// Enumerates the list of parameters and equivalence classes that are
    /// consumers of an object Y: when X uses Y,  X is represented in this object.
    /// </summary>
    public class ConsumerObjects
    {
        /// <summary>
        /// List of 0 or more parameter names.
        /// </summary>
        public IList<string> InputParameters { get; set; }

        /// <summary>
        /// List of 0 or more equivalence class names, represented as P.E, where
        /// P is the name of a parameter and E is the name of an equivalence class.
        /// </summary>
        public IList<string> EquivalenceClasses { get; set; }

        /// <summary>
        /// List of 0 or more expected result names.
        /// </summary>
        public IList<string> ExpectedResults { get; set; }

        /// <summary>
        /// List of 0 or more coverage group names.
        /// </summary>
        public IList<string> CoverageGroups { get; set; }

        /// <summary>
        /// Constructs and initializes an instance of class ConsumerObjects.
        /// </summary>
        public ConsumerObjects()
        {
            InputParameters = new List<string>();
            EquivalenceClasses = new List<string>();
            ExpectedResults = new List<string>();
            CoverageGroups = new List<string>();
        }

        public void AddInputParameterAsNeeded(string parameter)
        {
            if (!InputParameters.Contains(parameter))
            {
                InputParameters.Add(parameter);
            }
        }

        public void AddEquivalenceClassAsNeeded(string equivalenceClass)
        {
            if (!EquivalenceClasses.Contains(equivalenceClass))
            {
                EquivalenceClasses.Add(equivalenceClass);
            }
        }

        public void AddExpectedResultAsNeeded(string expectedResult)
        {
            if (!ExpectedResults.Contains(expectedResult))
            {
                ExpectedResults.Add(expectedResult);
            }
        }

        public void AddCoverageGroupAsNeeded(string coverageGroup)
        {
            if (!CoverageGroups.Contains(coverageGroup))
            {
                CoverageGroups.Add(coverageGroup);
            }
        }

        /// <summary>
        /// Returns a list of the consumers enumerated in this object.
        /// </summary>
        /// <returns></returns>
        public string ListOfConsumers()
        {
            IList<string> consumerLists = new List<string>();
            if (InputParameters.Any())
            {
                consumerLists.Add($"input parameters = {string.Join(",", InputParameters)}");
            }

            if (EquivalenceClasses.Any())
            {
                consumerLists.Add($"equivalence classes = {string.Join(",", EquivalenceClasses)}");
            }

            if (ExpectedResults.Any())
            {
                consumerLists.Add($"expected results = {string.Join(",", ExpectedResults)}");
            }

            if (CoverageGroups.Any())
            {
                consumerLists.Add($"coverage groups = {string.Join(",", CoverageGroups)}");
            }

            if (!consumerLists.Any())
            {
                return null;
            }

            return string.Join(";", consumerLists);
        }
    }
}
