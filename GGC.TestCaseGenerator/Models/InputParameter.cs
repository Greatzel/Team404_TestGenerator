using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    /// <summary>
    /// Class that encapsulates a test specification's input parameter.
    /// </summary>
    public class InputParameter
    {
        /// <summary>
        /// Specifies text for the GIVEN condition on the input parameter.
        /// </summary>
        public string Given { get; set; }

        /// <summary>
        /// The name of the input parameter from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the input parameter from the XML file.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A mapping of the equivalence classes' names onto their data.
        /// </summary>
        public IDictionary<string, EquivalenceClass> EquivalenceClasses { get; set; }

        /// <summary>
        /// LCondition that must be true in any test using this parameter.
        /// </summary>
        public Expression ConditionExpression { get; set; }

        /// <summary>
        /// Condition represented as strings (INFIX notation).
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class InputParameter.
        /// </summary>
        public InputParameter()
        {
            Given = null;
            Name = null;
            Text = null;
            EquivalenceClasses = null;
            ConditionExpression = null;
            Condition = null;
        }

        /// <summary>
        /// Constructs and initializes an instance object of the class InputParameter.
        /// </summary>
        public InputParameter(string name, string text)
        {
            Name = name;
            Text = text;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(
            string given,
            string name,
            string text,
            IDictionary<string, EquivalenceClass> equivalenceClasses,
            IList<Expression> conditions)
        {
            Given = given;
            Name = name;
            Text = text;
            EquivalenceClasses = equivalenceClasses;
            ConditionExpression = ((conditions == null) || !conditions.Any()) ? null : conditions[0];
            return true;
        }

        /// <summary>
        /// Parses the strings containing the expression conditions. Returns true if all are successful.
        /// </summary>
        public bool ParseConditions()
        {
            if (string.IsNullOrEmpty(Condition))
            {
                ConditionExpression = null;
                return true;
            }

            ConditionExpression = ExpressionParser.Parse(Condition);
            return ConditionExpression != null;
        }

        /// <summary>
        /// Validates the test specification and returns true if successful; otherwise false
        /// and returns an informative error message.
        /// </summary>
        public bool Validate(IList<string> errors)
        {
            bool validated = true;
            if ((EquivalenceClasses == null) || !EquivalenceClasses.Any())
            {
                errors.Add($"input parameter {Name} has no equivalence classes");
                validated = false;
            }
            else foreach (EquivalenceClass equivalenceClass in EquivalenceClasses.Values)
                {
                    validated = equivalenceClass.Validate(errors) && validated;
        }

            return validated;
        }
    }
}